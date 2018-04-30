using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RestServerDemo.Controllers
{
    public class DocumentController : ApiController
    {

        /*
         * Database object (entity framework)
         * In database i have table "Document"
         * with fields IdDoc, Owner, Doc.
        */
        RestDataBase db = new RestDataBase();


        // GET: api/Document
        public IEnumerable<Document> Get()
        {
            return db.Documents.ToList<Document>();
        }

        // GET: api/Document/5
        public Document Get(int id)
        {
            return db.Documents.Where(s => s.IdDoc == id).First();
        }

        // POST: api/Document
        public void Post([FromBody]Document value)
        {
            db.Documents.Add(value);
            db.SaveChanges();
        }

        // PUT: api/Document/5
        public void Put(int id, [FromBody]Document value)
        {
            Document updatedDocument = db.Documents.SingleOrDefault(s => s.IdDoc == id);
            updatedDocument = value;
            updatedDocument.IdDoc = id;
            db.Documents.AddOrUpdate(updatedDocument);
            db.SaveChanges();
        }

        // DELETE: api/Document/5
        public void Delete(int id)
        {
            Document removedDocument = db.Documents.Where(s => s.IdDoc == id).First();
            db.Documents.Remove(removedDocument);
            db.SaveChanges();
        }
    }
}
