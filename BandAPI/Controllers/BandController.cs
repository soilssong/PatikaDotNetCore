using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BandAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BandController : Controller
    {

        private static List<Band> _bands = new List<Band>()
        {
           new Band {id = 1 , Name = "Metallica" ,Country="Usa", Genre ="Heavy Metal" },
           new Band {id = 2 , Name = "The Beatles" ,Country="United Kingdom", Genre ="Rock" },
           new Band {id = 3 , Name = "Pink Floyd" ,Country="United Kingdom", Genre ="Rock" }

        };

       

        [HttpGet]
        public List<Band> GetBands()
        {
            var list = _bands.OrderBy(x => x.id).ToList();
            return list;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetBandById(int id)
        {
            var band = _bands.FirstOrDefault(x => x.id == id);
            if (band == null)
            {
               return BadRequest();
            }
            return Ok(band);
        }

        [HttpGet]
        [Route("[action]/{country}")]
        public IActionResult GettAllBandsByCountry(string country)
        {

            List<Band> bandsByCountry = new() { };

            if (country == null)
            {
                return BadRequest();
            }

            foreach (var item in _bands)
            {

                if (country.ToLower() == item.Country.ToLower())
                {
                    bandsByCountry.Add(item);
                }
            }
            
            return Ok(bandsByCountry);
            
           
        }




        [HttpGet]
        [Route("[action]")]

        // https://localhost:7012/Bands/GetBandByName?name=Metallica

        public IActionResult GetBandByName([FromQuery]string name)
        {
            var band = _bands.FirstOrDefault(x => x.Name.ToLower() == name);
            if (band == null)
            {
                return BadRequest();
            }
            return Ok(band);
        }

        [HttpPost]
        public IActionResult CreateBand([FromBody]Band _band)
        {
            var band = _bands.SingleOrDefault(x => x.Name == _band.Name);

            if(band != null)
            {
                return BadRequest();
            }
            _bands.Add(band);

            return Ok();
        }

      
        [HttpPut]
        public IActionResult UpdateBand([FromBody] Band _band)
        {
            var band = _bands.FirstOrDefault(x => x.id == _band.id);
            if(band is null)
            {
                return BadRequest();
            }
            band.Name = _band.Name;
            band.Genre = _band.Genre;
            band.Country = _band.Country;

            return Ok();
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteBand(int id)
        {
            var band = _bands.FirstOrDefault(x => x.id == id);


            if (band == null)
            {
                return BadRequest();
            }
            _bands.Remove(band);
          

            return Ok(band);
        }

        [HttpPatch()]
        [Route("UpdatePartial/{id:int}")]
        public IActionResult Patch(int id, JsonPatchDocument<Band> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest(ModelState);
            }

            var existed_band = _bands.FirstOrDefault(x => x.id == id);
            if (existed_band == null)
            {
                return NotFound();


            }
            var band = new Band
            {
                id = existed_band.id,
                Name = existed_band.Name,
                Genre = existed_band.Genre,
                Country = existed_band.Country,


            };

            patchDocument.ApplyTo(band,ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existed_band.Name = band.Name;
            existed_band.Genre = band.Genre;
            existed_band.Country = band.Country;

            return Ok(band);


        }
    }
}
