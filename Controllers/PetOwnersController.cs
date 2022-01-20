using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            return new List<PetOwner>();
        }

        // GET /api/petOwners/:id
        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {
        PetOwner owner = _context.PetOwners
            .SingleOrDefault(owner => owner.id == id);
            //SELECT * FROM PetOwners
            //WHERE owner.id = $1

        // Return a `404 Not Found` if the owner doesn't exist
        if (owner is null)
        {
            return NotFound();
        }

            return owner;
        }
        //POST api/petOwners
        [HttpPost]
        public PetOwner Post(PetOwner owner)
        {
        _context.Add(owner);
        _context.SaveChanges();

        return owner;
        }

        //DELETE api/petOwners/:id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Find the petowner, by ID
            PetOwner owner = _context.PetOwners.Find(id);

            // Tell the DB that we want to remove this owner
            _context.PetOwners.Remove(owner);

            // ...and save the changes to the database
            _context.SaveChanges(); ;
        }
    }

}

