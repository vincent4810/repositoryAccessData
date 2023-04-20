using Microsoft.AspNetCore.Mvc;
using Simplon.Data.Entity;
using Simplon.Data.Repository;

namespace Simplon.Data.Controller;



[ApiController]
[Route("/api/dog")]

public class FirstController: ControllerBase {

    private DogRepository dog12 = new DogRepository();

    [HttpGet]
    public IActionResult GetAll(){
        return Ok(dog12.FindAll());
    }

    [HttpPost]
    
    public IActionResult add(Dog dog){
        dog12.Save(dog);

        return Created($"/api/dog/{dog.Id}", dog);

    }

    
    [HttpGet("{id}")]

    public ActionResult<Dog> GetOne(int id){
        
        Dog dog = dog12.Find(id);

        if(dog == null){
            return NotFound();
        }

        return dog;

        // return Ok(dog12.Find(id));
    }

    [HttpDelete("{id}")]

    public ActionResult<Dog> Delete(int id){
        
        Dog dog = dog12.Find(id);

        if(dog == null){
            return NotFound();
        }
        dog12.Delete(dog);

        return NoContent();

    }

    [HttpPut("{id}")]

    public ActionResult<Dog> UpdateOne(int id, Dog dog){
        var toUpdate = dog12.Find(id);

        if(toUpdate == null){
            return NotFound();
        }

        dog.Id = id;
        dog12.Update(dog);
        return dog;
    }


     

}


