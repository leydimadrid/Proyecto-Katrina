using System;
using System.Net;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Services;

public class AutorService : IAutorService
{
    private readonly IUnitOfWork _unitOfWork;

    public AutorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<BaseMessage<Autor>> GetAllAutores()
    {
        var lista = await _unitOfWork.AutorRepository.GetAllAsync();
        return lista.Any()
            ? BuildMessage(lista.ToList(), "", HttpStatusCode.OK, lista.Count())
            : BuildMessage(lista.ToList(), "", HttpStatusCode.NotFound, 0);
    }

    public async Task<BaseMessage<Autor>> AddAutor(Autor autor)
    {
        var error = Validate.ValidateNameAutor(autor);
        if (error.Any())
        {
            return BuildMessage(null, string.Join("\n", error), HttpStatusCode.BadRequest, 0);
        }

        await _unitOfWork.AutorRepository.AddAsync(autor);
        await _unitOfWork.SaveAsync();
        return autor != null
            ? BuildMessage(new List<Autor> { autor }, "Autor agregado exitosamente.", HttpStatusCode.OK, 1)
            : BuildMessage(new List<Autor>(), "", HttpStatusCode.InternalServerError, 0);
    }

    public async Task<BaseMessage<Autor>> FindAutorById(int id)
    {
        var autor = await _unitOfWork.AutorRepository.FindAsync(id);
        return autor == null
            ? BuildMessage(new List<Autor>(), "", HttpStatusCode.NotFound, 0)
            : BuildMessage(new List<Autor> { autor }, "", HttpStatusCode.OK, 1);
    }

    public async Task<BaseMessage<Autor>> FindAutorByName(string nombre)
    {
        var lista = await _unitOfWork.AutorRepository.GetAllAsync(x => x.Nombre.ToLower().Contains(nombre.ToLower()));
        return lista.Any()
            ? BuildMessage(lista.ToList(), "", HttpStatusCode.OK, lista.Count())
            : BuildMessage(lista.ToList(), "", HttpStatusCode.NotFound, 0);
    }

    // public async Task<BaseMessage<Autor>> FindAutorByRange(int year1, int year2)
    // {

    //     var error = Validate.ValidateByRange(year1, year2);
    //     if (error.Any())
    //     {
    //         return BuildMessage(null, string.Join("\n", error), HttpStatusCode.BadRequest, 0);
    //     }

    //     var autor = await _unitOfWork.AutorRepository.GetAllAsync(autor => autor.Year >= year1 && autor.Year <= year2);
    //     return BuildMessage(autor.ToList(), "", HttpStatusCode.OK, autor.Count());
    // }

    public async Task<BaseMessage<Autor>> UpdateAutor(int id, Autor autor)
    {

        var autorEntity = await _unitOfWork.AutorRepository.FindAsync(id);
        if (autorEntity == null)
        {
            return BuildMessage(new List<Autor>(), "Autor no encontrado", HttpStatusCode.NotFound, 0);
        }

        autorEntity.Nombre = autor.Nombre;
        autorEntity.Apellido = autor.Apellido;

        _unitOfWork.AutorRepository.Update(autorEntity);
        await _unitOfWork.SaveAsync();
        return BuildMessage(new List<Autor> { autor }, "", HttpStatusCode.OK, 1);

    }

    public async Task<BaseMessage<Autor>> DeleteAutor(int id)
    {
        var autor = await _unitOfWork.AutorRepository.FindAsync(id);
        if (autor == null)
        {
            return BuildMessage(new List<Autor>(), "Autor no encontrado", HttpStatusCode.NotFound, 0);
        }

        _unitOfWork.AutorRepository.Delete(autor);
        await _unitOfWork.SaveAsync();
        return BuildMessage(new List<Autor> { autor }, "", HttpStatusCode.OK, 1);
    }

    private BaseMessage<Autor> BuildMessage(List<Autor> responseElements, string message = "", HttpStatusCode
    statusCode = HttpStatusCode.OK, int totalElements = 0)
    {
        return new BaseMessage<Autor>()
        {
            Message = message,
            StatusCode = statusCode,
            TotalElements = totalElements,
            ResponseElements = responseElements
        };
    }


}
