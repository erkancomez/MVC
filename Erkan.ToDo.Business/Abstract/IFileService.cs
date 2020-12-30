using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Abstract
{
    public interface IFileService
    {

        /// <summary>
        /// geriye üretmiş ve upload etmiş olduğu pdf dosyasının virtual pathini döner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string TranferPdf<T>(List<T> list) where T : class, new();
        /// <summary>
        /// geriye excel verisini byte dizisi olarak döner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] TransferExcel<T>(List<T> list) where T : class, new();
    }
}
