using System;
using TeslaACDC.Data;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;

public interface IAutorService
{
    public Task<BaseMessage<Autor>> GetAllAutores();
    public Task<BaseMessage<Autor>> FindAutorById(int id);
    public Task<BaseMessage<Autor>> FindAutorByName(string nombre);
    // public Task<BaseMessage<Autor>> FindAutorByRange(int year1, int year2);
    public Task<BaseMessage<Autor>> AddAutor(Autor autor);
    public Task<BaseMessage<Autor>> UpdateAutor(int id, Autor autor);
    public Task<BaseMessage<Autor>> DeleteAutor(int id);
}
