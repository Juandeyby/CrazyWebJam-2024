using UnityEngine;

public interface ITamagotchiView
{
   void UpdateHunger(int hunger);
   void UpdateHappiness(int happiness);
   void UpdateEnergy(int energy);
   void UpdateHygiene(int hygiene);
}
