using eWaveVolvoAPI.Models;
using eWaveVolvoAPI.Models.Entities;
using eWaveVolvoAPI.Models.Validation;

namespace eWaveVolvoAPI.Repositories
{
    public interface ITruckRepository
    {
        public Truck Select(int id);
        public List<Truck> List();
        public bool Insert(TruckObj truck);
        public bool Update(TruckObj truck);
        public bool Delete(int id);

    }

    public class TruckRepository : ITruckRepository
    {
        private readonly _DbContext db;
        private readonly TruckValidation valid;

        public TruckRepository(_DbContext _db)
        {
            db = _db;
            valid = new TruckValidation();
        }

        public Truck Select(int id)
        {
            try
            {
                var truck_db = db.Truck.Find(id);

                if (truck_db == null)
                    return new Truck();

                return truck_db;
            }
            catch
            {
                return new Truck();
            }

        }

        public List<Truck> List()
        {
            try
            {
                return db.Truck.ToList();
            }
            catch
            {
                return new List<Truck>();
            }
        }

        public bool Insert(TruckObj truck)
        {
            try
            {
                if (!valid.ValidateModel(truck.Model) || !valid.ValidateModelDate(truck.ModelYear) || !valid.ValidateProductionDate(truck.ProdYear))
                    return false;

                var truck_db = new Truck()
                {
                    Model = truck.Model,
                    ModelYear = truck.ModelYear,
                    ProdYear = truck.ProdYear,
                    Axes = truck.Axes,
                    GrossWeight = truck.GrossWeight,
                    LoadCapac = truck.LoadCapac,
                    MaxLenght = truck.MaxLenght
                };

                db.Truck.Add(truck_db);

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TruckObj truck)
        {
            try
            {
                if (!valid.ValidateModel(truck.Model) || !valid.ValidateModelDate(truck.ModelYear) || !valid.ValidateProductionDate(truck.ProdYear))
                    return false;

                var truck_db = db.Truck.Find(truck.ID);

                if (truck_db == null)
                    return false;

                truck_db.Model = truck.Model;
                truck_db.ModelYear = truck.ModelYear;
                truck_db.ProdYear = truck.ProdYear;
                truck_db.Axes = truck.Axes;
                truck_db.GrossWeight = truck.GrossWeight;
                truck_db.LoadCapac = truck.LoadCapac;
                truck_db.MaxLenght = truck.MaxLenght;

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var truck_db = db.Truck.Find(id);

                if (truck_db == null)
                    return false;

                db.Truck.Remove(truck_db);

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
