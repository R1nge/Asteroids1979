using Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Weapons;

public class GameScope : LifetimeScope
{
    [SerializeField] private BulletFactory bulletFactory;
    [SerializeField] private UIHandler uiHandler;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameManager>(Lifetime.Singleton);
        builder.RegisterEntryPoint<ScoreHandler>().AsSelf();
        builder.RegisterComponent(bulletFactory);
        builder.RegisterComponent(uiHandler);
    }
}