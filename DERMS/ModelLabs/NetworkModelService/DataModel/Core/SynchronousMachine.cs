using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class SynchronousMachine : RegulatingCondEq
    {
        
        private float maxQ;
        private float minQ;
        private float considerP;

      
        public float MaxQ { get => maxQ; set => maxQ = value; }
        public float MinQ { get => minQ; set => minQ = value; }
        public float ConsiderP { get => considerP; set => considerP = value; }

        public SynchronousMachine(long globalId) : base(globalId)
        {
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                SynchronousMachine x = (SynchronousMachine)obj;
                return (x.maxQ == this.maxQ && x.minQ == this.minQ && x.considerP == this.considerP);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.SYNCHRONOUSMACHINE_MAXQ:
                case ModelCode.SYNCHRONOUSMACHINE_MINQ:
                case ModelCode.SYNCHRONOUSMACHINE_CONSIDERP:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {

                case ModelCode.SYNCHRONOUSMACHINE_MAXQ:
                    prop.SetValue(maxQ);
                    break;

                case ModelCode.SYNCHRONOUSMACHINE_MINQ:
                    prop.SetValue(minQ);
                    break;
                
                case ModelCode.SYNCHRONOUSMACHINE_CONSIDERP:
                    prop.SetValue(considerP);
                    break;

                default:
                    base.GetProperty(prop);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                

                case ModelCode.SYNCHRONOUSMACHINE_MAXQ:
                    maxQ = property.AsFloat();
                    break;

                case ModelCode.SYNCHRONOUSMACHINE_MINQ:
                    minQ = property.AsFloat();
                    break;                
                
                case ModelCode.SYNCHRONOUSMACHINE_CONSIDERP:
                    considerP = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            //if (powerSystemResource != 0 && (refType != TypeOfReference.Reference || refType != TypeOfReference.Both))
            //{
            //    references[ModelCode.MEASUREMENT_PSR] = new List<long>();
            //    references[ModelCode.MEASUREMENT_PSR].Add(powerSystemResource);
            //}

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation
    }
}
