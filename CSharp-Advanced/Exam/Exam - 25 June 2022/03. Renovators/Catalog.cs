using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> Collection;
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int neededRenovators;
        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }
        private string project;
        public string Project
        {
            get { return project; }
            set { project = value; }
        }

        public Catalog (string name, int neededRenovators, string project)
        {
            this.Collection = new List<Renovator>();
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
        }


        public string AddRenovator(Renovator renovator)
        {
            if (this.Collection.Count < this.NeededRenovators)
            {
                if (renovator.Name == null || renovator.Type == null || renovator.Name == string.Empty || renovator.Type == string.Empty)
                {
                    return "Invalid renovator's information.";
                }
                else
                {
                    if (renovator.Rate >= 350)
                    {
                        return "Invalid renovator's rate.";
                    }
                    else
                    {
                        this.Collection.Add(renovator);
                        return $"Successfully added {renovator.Name} to the catalog.";
                    }
                }
            }
            else
            {
                return "Renovators are no more needed.";
            }


            //if ((renovator.Name != null && renovator.Type != null && renovator.Name != string.Empty && renovator.Type != string.Empty))
            //{
            //    if (this.Collection.Count + 1 > this.NeededRenovators)
            //    {
            //        return "Renovators are no more needed.";
            //    }
            //    else if (this.Collection.Count + 1 <= this.NeededRenovators)
            //    {
            //        if (renovator.Rate > 350)
            //        {
            //            return "Invalid renovator's rate.";
            //        }
            //        else if (renovator.Rate <= 350)
            //        {
            //            this.Collection.Add(renovator);
            //        }
            //    }
            //}
            //else if (renovator.Name == null || renovator.Type == null || renovator.Name == string.Empty || renovator.Type == string.Empty)
            //{
            //    return "Invalid renovator's information.";
            //}
            //return $"Successfully added {renovator.Name} to the catalog.";
            
        }
        public bool RemoveRenovator(string name)
        {
            int index = this.Collection.FindIndex(x => x.Name == name);
            if (index > -1)
            {
                this.Collection.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }


            //int index = 0;
            //bool removed = false;
            //for (int i = 0; i < this.Count; i++)
            //{
            //    if (this.Collection[i].Name == name)
            //    {
            //        index = i;
            //        removed = true;
            //        break;
            //    }
            //}
            //if (removed == true)
            //this.Collection.RemoveAt(index);
            //return removed;


        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            return this.Collection.RemoveAll(x => x.Type == type);
            

            //int count = 0;
            //for (int i = 0; i < this.Count; i++)
            //{
            //    if (this.Collection[i].Type == type)
            //    {
            //        count++;
            //        this.Collection.RemoveAt(i);
            //        i--;
            //    }
            //}
            //return count;
        }
        public Renovator HireRenovator(string name)
        {
            int index = this.Collection.FindIndex(x => x.Name == name);
            if (index > -1)
            {
                this.Collection[index].Hired = true;
                return this.Collection[index];
            }
            else
            {
                return null;
            }


            //int index = -1;
            //for (int i = 0; i < this.Count; i++)
            //{
            //    if (this.Collection[i].Name == name)
            //        index = i;
            //}

            //if (index == -1)
            //    return null;
            //else
            //    return this.Collection[index];
        }
        public List<Renovator> PayRenovators(int days)
        {
            return this.Collection.FindAll(x => x.Days >= days);

            //return this.Collection.Where(x => x.Days >= days).ToList();


            //List<Renovator> result = new List<Renovator>();

            //for (int i = 0; i < this.Count; i++)
            //{
            //    if (this.Collection[i].Days >= days)
            //    {
            //        result.Add(this.Collection[i]);
            //    }
            //}

            //return result;

        }
        public int Count { get { return this.Collection.Count; } }
        public string Report()
        {
            return $"Renovators available for Project {this.Project}: {Environment.NewLine}" +
                   String.Join(Environment.NewLine, this.Collection.Where(x => x.Hired == false));
        }
    }
}
