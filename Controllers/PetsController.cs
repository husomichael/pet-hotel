using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return new List<Pet>();
        }


        // GET /api/pets/:id
        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
        Pet pet = _context.Pets
            .SingleOrDefault(pet => pet.id == id);
            //SELECT * FROM PetOwners
            //WHERE owner.id = $1

        // Return a `404 Not Found` if the owner doesn't exist
        if (pet is null)
        {
            return NotFound();
        }

            return pet;
        }

        //POST api/pets
        [HttpPost]
        public Pet Post(Pet pet)
        {
        _context.Add(pet);
        _context.SaveChanges();

        return pet;
        }

        //DELETE api/pets/:id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Find the petowner, by ID
            Pet pet = _context.Pets.Find(id);

            // Tell the DB that we want to remove this owner
            _context.Pets.Remove(pet);

            // ...and save the changes to the database
            _context.SaveChanges(); ;
        }

        //PUT /api/pets/:id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pet petToUpdate)
        {

            //Find the Pet object from PetList that we need to update
            Pet pet = _context.Pets.Find(id);

            if (pet == -1)
            {
            return NotFound();
            }

            //Update that Pet object with the "petToUpdate" data that comes
            //into this route.
            pet = petToUpdate;
            _context.SaveChanges();
            return Ok();
        }
    }
}

