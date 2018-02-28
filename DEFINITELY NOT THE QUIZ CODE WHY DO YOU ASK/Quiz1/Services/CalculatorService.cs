using Quiz1.Models;

namespace Quiz1.Services
{
    public class CalculatorService
    {
        public CalculatorService(CalculatorModel model)
        {
            Model = model;
        }

        public CalculatorModel Model { get; set; }

        public CalculatorModel Calculate()
        {
            switch (Model.Action)
            {
                case "add":
                    Model.Result = Model.Left + Model.Right;
                    Model.Action = "+";
                    break;
                case "subtract":
                    Model.Result = Model.Left - Model.Right;
                    Model.Action = "-";
                    break;
                case "multiply":
                    Model.Result = Model.Left * Model.Right;
                    Model.Action = "*";
                    break;
                case "divide":
                    Model.Result = Model.Left / Model.Right;
                    Model.Action = "/";
                    break;
            }

            return Model;
        }
    }
}