using UnityEngine;

public interface ITamagotchiView
{
   void UpdateSatiety(float satiety);
   void UpdateHappiness(float happiness);
   void UpdateEnergy(float energy);
   void UpdateHygiene(float hygiene);
}
