using System;
using System.Collections.Generic;

namespace TestHwProj2
{
    public class Entity1
    {
        public int EntityId { get; set; }
        public string Data { get; set; }
        public DateTime CreationTime { get; set; }
        public int? Entity2Id { get; set; }
        public bool Flag { get; set; }

        public Entity1(int entityId, string data, DateTime creationTime, int? entity2Id, bool flag)
        {
            EntityId = entityId;
            Data = data;
            CreationTime = creationTime;
            Entity2Id = entity2Id;
            Flag = flag;
        }
    }

    public class Entity2
    {
        public int EntityId { get; set; }
        public double Data { get; set; }
        public DateTime CreationDate { get; set; }

        public Entity2(int entityId, double data, DateTime creationDate)
        {
            EntityId = entityId;
            Data = data;
            CreationDate = creationDate;
        }
    }

    public class EntityAggregate
    {
        public int EntityId { get; set; }
        public string Data { get; set; }
        public DateTime CreationTime { get; set; }
        public bool Flag { get; set; }
        public Entity2 Entity2 { get; set; }

        public EntityAggregate(Entity1 entity1, Entity2 entity2)
        {
            EntityId = entity1.EntityId;
            Data = entity1.Data;
            CreationTime = entity1.CreationTime;
            Flag = entity1.Flag;
            Entity2 = entity2;
        }
    }

    class Program
    {
        private static Entity2 FindEntity2(Entity2[] e2, int? entityId)
        {
            if (entityId == null)
            {
                return null;
            }

            foreach (var entity in e2)
            {
                if (entity.EntityId == entityId)
                {
                    return entity;
                }
            }

            return null;
        }

        public static EntityAggregate[] Join(Entity1[] e1, Entity2[] e2, bool hasFlag)
        {
            var list = new List<EntityAggregate>();

            foreach (var entity1 in e1)
            {
                if (hasFlag != entity1.Flag)
                {
                    continue;
                }

                Entity2 entity2 = FindEntity2(e2, entity1.Entity2Id);
                var entityAggregate = new EntityAggregate(entity1, entity2);
                list.Add(entityAggregate);
            }

            return list.ToArray();
        }

        static void Main(string[] args)
        {
            Entity1[] e1 = { new Entity1(1, "data1", new DateTime(2000, 10, 5), 1, true),
                             new Entity1(2, "data2", new DateTime(2003, 11, 7), 3, false),
                             new Entity1(3, "data3", new DateTime(2005, 8, 2), 2, true) };
            Entity2[] e2 = { new Entity2(1, 2.5, new DateTime(1999, 2, 3)),
                             new Entity2(2, 3.5, new DateTime(1998, 2, 3)),
                             new Entity2(3, 4.5, new DateTime(1978, 2, 3)) };

            var e3 = Join(e1, e2, true);
        }
    }
}