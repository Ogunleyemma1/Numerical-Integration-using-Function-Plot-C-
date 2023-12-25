using System;
using System.Collections;
using System.Collections.Generic;
using oompe.lib;
using org.mariuszgromada.math.mxparser;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;


public class NumericalIntegral {

    private double startTime, endTime;

    private double Pt;

    private double analyticalEnergy; //Result from the hand calculated integration


    private Function F;

    private FunctionPlotter plotter;


    public NumericalIntegral(Function F, double startTime, double endTime){

        this.F = F;
        this.startTime = startTime;
        this.endTime = endTime;
        this.plotter = new FunctionPlotter(this.F, this.startTime, this.endTime);
        
    }


    public void Plot(GameObject plane){

        this.plotter.Plot(plane);
    }


    
    public double AnalyticalIntegral(){

        //Calculating time interval using the result of the analytical integral
        Function E = new Function($" E(t) = (126829*t^2/(40000*2)) - (cos(2*pi*2*t)/(pi*2))");
        double E1 = E.calculate(this.startTime);
        double E2 = E.calculate(this.endTime);

        analyticalEnergy = E2 - E1;

        Debug.Log($"The Analytically Calculated Energy for the analytical integration is {analyticalEnergy}");

        return analyticalEnergy; 

    }



    public double NumericalIntergralMethod1(){

        //for visuals
        this.plotter.ClearPoints();
        this.plotter.ClearAdditionalLines();

        double t1 = this.startTime;
        double energyMethod1 = 0;
        int steps = 0;

        while(steps < plotter.FunctionPoints.Count-1 && t1>= this.startTime){
        //Calling out the coordinate for the first and second points
        t1 = plotter.FunctionPoints[steps].x;
        double t2 = plotter.FunctionPoints[steps + 1].x;
        Pt = plotter.FunctionPoints[steps].y;
        energyMethod1 += Pt * (t2 - t1);
        steps++;

        //Calculating the absolute and relative error
        double absoluteError = Math.Abs(analyticalEnergy - energyMethod1);
        double relativeError = absoluteError*100/analyticalEnergy;


        Debug.Log($" The Value of the Numerical Integrations using method 1 is {energyMethod1}");
        Debug.Log($" The absolute error is calculated as {absoluteError} and the relative error is calculated as {relativeError}%");


        //For Visuals
        Vector2 p1 = new Vector2((float)t1, 0);
        Vector2 p2 = new Vector2((float)t1, (float)Pt);
        this.plotter.AddLine(p1, p2);
        Vector2 p3 = new Vector2((float)t2, (float)Pt);
        this.plotter.AddLine(p2, p3);
        Vector2 p4 = new Vector2((float)t2, 0);
        this.plotter.AddLine(p3, p4);

        }

        return energyMethod1;

    }


    public double NumericalIntegralMethod2(){

        //for visuals
        this.plotter.ClearPoints();
        this.plotter.ClearAdditionalLines();

        double t1 = this.startTime;
        double energyMethod2 = 0;
        int steps = 0;

        while(steps < plotter.FunctionPoints.Count-1 && t1>=this.startTime){

            t1 = plotter.FunctionPoints[steps].x;
            double t2 = plotter.FunctionPoints[steps + 1].x;
            double Pt1 = plotter.FunctionPoints[steps].y;
            double Pt2 = plotter.FunctionPoints[steps +1].y;

            energyMethod2 += 0.5*(Pt1 + Pt2) * (t2 - t1);
            steps++;

            //Calculating the absolute and relative error
            double absoluteError = Math.Abs(analyticalEnergy - energyMethod2);
            double relativeError = absoluteError*100/analyticalEnergy;


            Debug.Log($" The Value of the Numerical Integrations using method 1 is {energyMethod2}");
            Debug.Log($" The absolute error is calculated as {absoluteError} and the relative error is calculated as {relativeError}%");

            //for visuals
            Vector2 p1 = new Vector2((float)t1, 0);
            Vector2 p2 = new Vector2((float)t1, (float)(0.5 *(Pt2 + Pt1)));
            this.plotter.AddLine(p1, p2);
            Vector2 p3 = new Vector2((float)t2, (float)(0.5 *(Pt2 + Pt1)));
            this.plotter.AddLine(p2, p3);
            Vector2 p4 = new Vector2((float)t2, 0);
            this.plotter.AddLine(p3, p4);


        }

        return energyMethod2;


    }


    public double NumericalIntegralMethod3(){

        //for visuals
        this.plotter.ClearPoints();
        this.plotter.ClearAdditionalLines();

        double t1 = this.startTime;
        double energyMethod3 = 0;
        int steps = 0;

        while(steps<plotter.FunctionPoints.Count-1 && t1>= this.startTime){

            t1 = plotter.FunctionPoints[steps].x;
            double t2 = plotter.FunctionPoints[steps+1].x;
            double Pt1 = plotter.FunctionPoints[steps].y;
            double Pt2 = plotter.FunctionPoints[steps+1].y;

            energyMethod3 += 0.5 * (Pt1 + Pt2) * (t2 - t1); // using area of a trapezium 0.5(a+b)h
            steps++;

            //Calculating the absolute and relative error
            double absoluteError = Math.Abs(analyticalEnergy - energyMethod3);
            double relativeError = absoluteError*100/analyticalEnergy;


            Debug.Log($" The Value of the Numerical Integrations using method 1 is {energyMethod3}");
            Debug.Log($" The absolute error is calculated as {absoluteError} and the relative error is calculated as {relativeError}%");

            //For Visual
            Vector2 p1 = new Vector2((float)t1, 0);
            Vector2 p2 = new Vector2((float)t1, (float)Pt1);
            this.plotter.AddLine(p1, p2);
            Vector2 p3 = new Vector2((float)t2, 0);
            Vector2 p4 = new Vector2((float)t2, (float)Pt2);
            this.plotter.AddLine(p3, p4);


        }

        return energyMethod3;
        
    }


    }



        
    
