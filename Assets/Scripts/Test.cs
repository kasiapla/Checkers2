using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Test : MonoBehaviour
{
    Action<AB, int> action;
    Func<AB, bool> func;
    class AB
    {
        public int A;
        public string B;

        public AB(int _A, string _B)
        {
            A = _A;
            B = _B;
        }
    }

    List<AB> ABs = new List<AB> { new AB(1, "a"), new AB(2, "b"), new AB(20, "ble"), new AB(7, "mniam") };
    void Start()
    {
        action = FukcjaInna;
        func = (AB obj) => obj.A < 10;

        func += Funkcja;
        var ABpartial = ABs.Find((AB obj) => obj.A < 10);
        var ABpartial2 = ABs.Find(Funkcja);
        var ABpartial3 = ABs.Find((AB obj) =>
                                            {
                                                bool isTrue = obj.A < 10;
                                                if (isTrue)
                                                {
                                                  Debug.Log(obj.B);
                                                }
                                                return isTrue;
                                            });
        action(ABs[0], 2);
        action?.Invoke(ABs[1], 3);

        
        bool? ABpartial4 = func?.Invoke(ABs[3]);
    }

    bool Funkcja(AB ab)
    {
        return ab.A < 10;

    }

    void FukcjaInna(AB ab, int i) { }
}
