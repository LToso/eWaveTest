namespace eWaveVolvoAPI.Models.Validation
{
    public class TruckValidation
    {
        public bool ValidateModel(string model)
        {
            return (model == "FH" || model == "FM");
        }

        public bool ValidateProductionDate(int year)
        {
            return (year == DateTime.Now.Year);
        }

        public bool ValidateModelDate(int year)
        {
            return (year == DateTime.Now.Year || year == DateTime.Now.Year + 1) ;
        }
    }
}
