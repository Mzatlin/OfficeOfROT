using System;
public interface ILoadScene
{
    void LoadScene();
    event Action OnLevelLoad;
}