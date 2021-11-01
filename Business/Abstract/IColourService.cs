using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColourService
    {
        IDataResult<List<Colour>> GetAll();
        IDataResult<Colour> GetById(int id);
        IResult Add(Colour colour);
        IResult Delete(Colour colour);
        IResult Update(Colour colour);
        IDataResult<Colour> GetByName(string colorName);
    }
}
