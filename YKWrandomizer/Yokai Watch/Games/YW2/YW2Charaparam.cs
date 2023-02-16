﻿using System;
using YKWrandomizer.Tool;

namespace YKWrandomizer.Yokai_Watch.Games.YW2
{
    public class YW2Charaparam
    {
        public long Length;

        public long Offset;

        public UInt32 ParamID;

        public UInt32 BaseID;

        public int[] MinStat;

        public int[] MaxStat;

        public UInt32 AttackID;

        public UInt32 TechniqueID;

        public UInt32 InspiritID;

        public UInt32 SoultimateID;

        public UInt32 FoodID;

        public UInt32 SkillID;

        public int Money;

        public int Experience;

        public UInt32[] DropID;

        public int[] DropRate;

        public int ExperienceCurve;

        public UInt32[] QuoteID;

        public int EvolveOffset;

        public int MedaliumOffset;

        public int FavoriteDonut;

        public float[] AttributeDamage;

        public bool Scoutable;

        public UInt32 ScoutableID;

        public YW2Charaparam()
        {

        }

        public void Read(DataReader reader)
        {
            Length = reader.Length;

            reader.Skip(0x14);

            ParamID = reader.ReadUInt32();
            BaseID = reader.ReadUInt32();

            MinStat = new int[5];
            for (int i = 0; i < 5; i++)
            {
                MinStat[i] = reader.ReadInt32();
            }

            MaxStat = new int[5];
            for (int i = 0; i < 5; i++)
            {
                MaxStat[i] = reader.ReadInt32();
            }

            FavoriteDonut = reader.ReadInt32();

            AttackID = reader.ReadUInt32();
            reader.Skip(0x04);

            TechniqueID = reader.ReadUInt32();
            reader.Skip(0x04);

            InspiritID = reader.ReadUInt32();
            reader.Skip(0x04);

            // Unknow byte
            reader.Skip(0x0C);

            AttributeDamage = new float[6];
            for (int i = 0; i < 6; i++)
            {
                AttributeDamage[i] = reader.ReadSingle();
            }

            SoultimateID = reader.ReadUInt32();
            reader.Skip(0x04);

            // Unknow byte
            reader.Skip(0x04);

            ScoutableID = reader.ReadUInt32();
            if (ScoutableID == 0x00 || ScoutableID == 0x05 || ScoutableID == 0x0A)
            {
                Scoutable = false;
            }
            else
            {
                Scoutable = true;
            }

            SkillID = reader.ReadUInt32();
            Money = reader.ReadInt32();
            Experience = reader.ReadInt32();
            reader.Skip(0x04);

            DropID = new UInt32[2];
            DropRate = new int[2];
            for (int i = 0; i < 2; i++)
            {
                DropID[i] = reader.ReadUInt32();
                DropRate[i] = reader.ReadInt32();
            }

            // Unknow byte
            reader.Skip(0x08);

            ExperienceCurve = reader.ReadInt32();

            QuoteID = new UInt32[4];
            for (int i = 0; i < 4; i++)
            {
                QuoteID[i] = reader.ReadUInt32();
            }

            // Unknow byte
            reader.Skip(0x04);

            EvolveOffset = reader.ReadInt32();
            MedaliumOffset = reader.ReadInt32();
        }

        public void Write(DataWriter writer)
        {
            writer.Seek((uint)Offset);
            writer.Skip(0x14);

            writer.WriteUInt32(ParamID);
            writer.WriteUInt32(BaseID);

            for (int i = 0; i < 5; i++)
            {
                writer.WriteInt32(MinStat[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                writer.WriteInt32(MaxStat[i]);
            }

            writer.WriteInt32(FavoriteDonut);

            writer.WriteUInt32(AttackID);
            writer.Skip(0x04);

            writer.WriteUInt32(TechniqueID);
            writer.Skip(0x04);

            writer.WriteUInt32(InspiritID);
            writer.Skip(0x04);

            // Unknow byte
            writer.Skip(0x0C);

            for (int i = 0; i < 6; i++)
            {
                if (AttributeDamage[i] == 0x00)
                {
                    writer.WriteInt32(0x01);
                } else
                {
                    writer.Write(AttributeDamage[i]);
                }
                
            }

            writer.WriteUInt32(SoultimateID);
            writer.Skip(0x04);

            // Unknow byte
            writer.Skip(0x04);

            writer.WriteUInt32(ScoutableID);
            writer.WriteUInt32(SkillID);
            writer.WriteInt32(Money);
            writer.WriteInt32(Experience);
            writer.Skip(0x04);

            for (int i = 0; i < 2; i++)
            {
                writer.WriteUInt32(DropID[i]);
                writer.WriteInt32(DropRate[i]);
            }

            // Unknow byte
            writer.Skip(0x08);

            writer.WriteInt32(ExperienceCurve);

            for (int i = 0; i < 4; i++)
            {
                writer.WriteUInt32(QuoteID[i]);
            }

            // Unknow byte
            writer.Skip(0x04);

            writer.WriteInt32(EvolveOffset);
            writer.WriteInt32(MedaliumOffset);
        }
    }
}
