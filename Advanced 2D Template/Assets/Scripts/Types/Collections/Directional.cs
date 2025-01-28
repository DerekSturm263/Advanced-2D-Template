using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Types.Collections
{
    [Serializable]
    public struct Directional<T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ICollection, Interfaces.IRotatable<Directional<T>>
    {
        public enum Direction
        {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest
        }

        [SerializeField] private T _north;
        [SerializeField] private T _northEast;
        [SerializeField] private T _east;
        [SerializeField] private T _southEast;
        [SerializeField] private T _south;
        [SerializeField] private T _southWest;
        [SerializeField] private T _west;
        [SerializeField] private T _northWest;

        public readonly int Count => 8;
        public readonly bool IsSynchronized => true;
        public readonly object SyncRoot => default;

        public readonly T this[Direction direction] => direction switch
        {
            Direction.North => _north,
            Direction.NorthEast => _northEast,
            Direction.East => _east,
            Direction.SouthEast => _southEast,
            Direction.South => _south,
            Direction.SouthWest => _southWest,
            Direction.West => _west,
            Direction.NorthWest => _northWest,
            _ => throw new IndexOutOfRangeException()
        };

        public Directional(T north, T northEast, T east, T southEast, T south, T southWest, T west, T northWest)
        {
            _north = north;
            _northEast = northEast;
            _east = east;
            _southEast = southEast;
            _south = south;
            _southWest = southWest;
            _west = west;
            _northWest = northWest;
        }

        public readonly Directional<T> Rotate90() => new(_west, _northWest, _north, _northEast, _east, _southEast, _south, _southWest);
        public readonly Directional<T> Rotate180() => new(_south, _southWest, _west, _northWest, _north, _northEast, _east, _southEast);
        public readonly Directional<T> Rotate270() => new(_east, _southEast, _south, _southWest, _west, _northWest, _north, _northEast);

        public readonly void CopyTo(Array array, int index)
        {
            array.SetValue(_north, 0);
            array.SetValue(_northEast, 1);
            array.SetValue(_east, 2);
            array.SetValue(_southEast, 3);
            array.SetValue(_south, 4);
            array.SetValue(_southWest, 5);
            array.SetValue(_west, 6);
            array.SetValue(_northWest, 7);
        }

        public readonly IEnumerator<T> GetEnumerator()
        {
            yield return _north;
            yield return _northEast;
            yield return _east;
            yield return _southEast;
            yield return _south;
            yield return _southWest;
            yield return _west;
            yield return _northWest;
        }

        readonly IEnumerator IEnumerable.GetEnumerator()
        {
            yield return _north;
            yield return _northEast;
            yield return _east;
            yield return _southEast;
            yield return _south;
            yield return _southWest;
            yield return _west;
            yield return _northWest;
        }
    }
}
