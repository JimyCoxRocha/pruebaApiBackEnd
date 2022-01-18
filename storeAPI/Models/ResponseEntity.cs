using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAPI.Models
{
    public class ResponseEntity<T>
    {
        public String CodigoRetorno { get; set; }
        public String MensajeRetorno { get; set; }
        public T Data{ get; set; }

        public static ResponseEntity<T> resp(String codigoRetorno, T data)
        {
            ResponseEntity<T> resp = new ResponseEntity<T>();
            resp.CodigoRetorno = codigoRetorno;
            resp.MensajeRetorno = "Proceso correcto";
            resp.Data = data;
            return resp;
        }
        public static ResponseEntity<T> error(String codigoRetorno)
        {
            ResponseEntity<T> resp = new ResponseEntity<T>();
            resp.CodigoRetorno = codigoRetorno;
            resp.MensajeRetorno = "ERROR";
            return resp;
        }

    }
}
