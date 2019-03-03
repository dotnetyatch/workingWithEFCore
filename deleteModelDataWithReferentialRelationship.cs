        public void deleteData(int recordid)
        {
            
            var tripstoberemoved= (_context.trips.Single(t => t.Id == recordid)); //retrieve primary records
            var stopstoberemoved = _context.stops.Where(s => EF.Property<int>(s, "TripId") == recordid); // TripId is shadow property automatically created on child records
            foreach (var stoptoberemoved in stopstoberemoved) // iterate through child records
            {
                tripstoberemoved.Stops.Remove(stoptoberemoved);
            }
            _context.Remove(tripstoberemoved); // remove trips
            _context.SaveChanges(); // commit changes
        }
