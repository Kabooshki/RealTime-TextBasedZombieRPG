using System;
using System.Collections.Generic;

public class Item
{
    public string Name { get; set;}
    public string Description {get; set;}
    public int Quality {get; set;} // range between 0.0 and 1.0
    
    private Dictionary<Type, IItemComponent> _components = new();

    public void AddComponent<T>(T component) where T : IItemComponent
    {
        _components[typeof(T)] = component;
    }
    
    // ? = Null Conditional Operator
    public T? GetComponent<T>() where T : IItemComponent
    {
        _components.TryGetValue(typeof(T), out var component);
        return (T?)component;
    }

    public interface IItemComponent { }

    public interface IDamage : IItemComponent
    {
        int GetDamage();
    }

    public interface IConsumable : IItemComponent
    {
        void Consume(Player player);
    }

    public interface IEquippable : IItemComponent
    {
        // usage example: 
        // var chestplate = new Item { Name = "Iron Chestplate", Description = "Heavy protection" };
        // chestplate.AddComponent<IEquippable>(new ArmorComponent { DefenseBonus = 10 });
        // chestplate.GetComponent<IEquippable>()?.Equip(player);

        void Equip(Player player);
        void Unequip(Player player);
    }
}
