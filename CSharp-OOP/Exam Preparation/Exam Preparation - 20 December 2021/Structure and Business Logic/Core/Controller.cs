namespace NavalVessels.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Contracts;
    using NavalVessels.Models;
    using NavalVessels.Utilities.Messages;
    using Repositories;

    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
            ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == fullName);

            if (captain is null)
            {
                this.captains.Add(captain);
                return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
            }

            return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = this.vessels.FindByName(name);
            if (vessel != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);

                this.vessels.Add(vessel);
            }
            else if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);

                this.vessels.Add(vessel);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }

            return String.Format(
                OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            if (captain is null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            IVessel vessel = this.vessels.FindByName(selectedVesselName);
            if (vessel is null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            vessel.Captain = captain;
            captain.Vessels.Add(vessel);
            return String.Format(
                OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }
        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            return vessel.ToString();
        }
        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel is null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == "Battleship")
            {
                IBattleship battleship = vessel as IBattleship;
                battleship.ToggleSonarMode();

                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                ISubmarine battleship = vessel as ISubmarine;
                battleship.ToggleSubmergeMode();

                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }
        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel is null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackVessel = this.vessels.FindByName(attackingVesselName);
            IVessel defendingVessel = this.vessels.FindByName(defendingVesselName);

            if (attackVessel is null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            else if (defendingVessel is null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attackVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            else if (defendingVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackVessel.Attack(defendingVessel);

            return String.Format(
                OutputMessages.SuccessfullyAttackVessel,
                defendingVesselName,
                attackingVesselName,
                defendingVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == captainFullName);

            return captain.Report();
        }





    }
}
