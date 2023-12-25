using System;
using System.Collections;
using System.Collections.Generic;
using oompe.lib;
using org.mariuszgromada.math.mxparser;
using UnityEngine;

public class PowerCalculations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //Plotting the functions for the numerical integration using Method 1
        Function P = new Function($"P(t) = (126829*t/40000) + sin(2*pi*2*t) ");
        NumericalIntegral plotter = new NumericalIntegral(P, 0, 20);
        double error = plotter.AnalyticalIntegral();
    
        //double integrationMethod1 = plotter.NumericalIntergralMethod1();
        //double integrationMethod2 = plotter.NumericalIntegralMethod2();
        double integrationMethod3 = plotter.NumericalIntegralMethod3();
        plotter.Plot(this.gameObject);


        
    }

    // Update is called once per frame

}
