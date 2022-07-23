namespace _07._Military_Elite.Models.Intefaces
{
    using System.Collections.Generic;
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<Private> Privates { get;}
    }
}
