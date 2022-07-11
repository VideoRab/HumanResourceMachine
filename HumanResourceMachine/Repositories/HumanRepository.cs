﻿using HumanResourceMachine.Context;
using HumanResourceMachine.Entities;
using HumanResourceMachine.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceMachine.Repositories
{
    public class HumanRepository : IHumanRepository
    {
        private readonly HRMContext _context;

        public HumanRepository(HRMContext context)
        {
            _context = context;
        }

        public IEnumerable<Human> GetAllHumans()
        {
            return _context.People.ToList();
        }

        public Human GetHumanById(int id)
        {
            return _context.People.Find(id);
        }

        public void AddHuman(Human human)
        {
            _context.People.Add(human);
            _context.SaveChanges();
        }

        public void UpdateHuman(Human human)
        {
            _context.Entry(human).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteHumanById(int id)
        {
            var target = _context.People.Find(id);
            _context.People.Remove(target!);
            _context.SaveChanges();
        }
    }
}