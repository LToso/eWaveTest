using eWaveVolvoAPI.Models.Validation;

namespace eWaveVolvoTest
{
    public class TruckTest
    {
        private readonly TruckValidation valid = new TruckValidation();

        [Fact]
        public void ModelValidation()
        {
            Assert.True(valid.ValidateModel("FH"));
            Assert.True(valid.ValidateModel("FM"));
        }

        [Fact]
        public void ProductionDateValidation()
        {
            Assert.True(valid.ValidateProductionDate(DateTime.Now.Year));
        }

        [Fact]
        public void ModelDateValidation()
        {
            Assert.True(valid.ValidateModelDate(DateTime.Now.Year));
            Assert.True(valid.ValidateModelDate(DateTime.Now.Year + 1));
        }
    }
}