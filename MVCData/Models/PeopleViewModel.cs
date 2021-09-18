﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCData.Models
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; }        
        public string SearchString { get; set; }      
        public CreatePersonViewModel CreatePersonViewModel { get; set; }

        public List<Person> Search()
        {
            List<Person> searchResult = new List<Person>();
            foreach (Person p in People)
            {
                if (p.City.Equals(SearchString))
                {
                    searchResult.Add(p);
                }
            }
            return searchResult;
        }
    }
}
