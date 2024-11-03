using UnityEngine;

public interface ITamagotchiPresenter
{
    void UpdateView();
    void Feed(int amount);
    void Play(int amount);
    void Sleep(int amount);
    void Clean(int amount);
}
