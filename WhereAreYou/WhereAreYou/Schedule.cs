﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WhereAreYou
{
    public class Schedule : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string moduleName;
        private string roomID;
        private string day;
        private float starttime;
        private float endtime;

        public Schedule()
        {

        }

        public string ModuleName
        {
            get { return moduleName; }
            set
            {
                if (moduleName == value) return;
                moduleName = value;
                OnPropertyChanged();
            }
        }

        public string RoomID
        {
            get { return roomID; }
            set
            {
                if (roomID == value) return;
                roomID = value;
                OnPropertyChanged();
            }
        }

        public string Day
        {
            get { return day; }
            set
            {
                if (day == value) return;
                day = value;
                OnPropertyChanged();
            }
        }

        public float StartTime
        {
            get { return starttime; }
            set
            {
                if (starttime == value) return;
                starttime = value;
                OnPropertyChanged();
            }
        }

        public float EndTime
        {
            get { return endtime; }
            set
            {
                if (endtime == value) return;
                endtime = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}