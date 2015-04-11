using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using LumenWorks.Framework.IO.Csv;

public class DataRender : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public class CrimeEntry /**This is information about data that you might want**/
	{
		public string shift;
		public string offense;
		public string method;
		public string ward;
		public string district;
		public string reportDate;
	}
	
	List<CrimeEntry> loadCrimes ()
	{
		Dictionary<string, int> myObjectMap = new Dictionary<string, int> ();
		List<CrimeEntry> crimeList = new List<CrimeEntry> ();
		using (CsvReader csv = new CsvReader(new StreamReader("data.csv"), true)) {
			int fieldCount = csv.FieldCount;
			string[] headers = csv.GetFieldHeaders ();
			
			for (int i = 0; i < fieldCount; i++) {
				myObjectMap [headers [i]] = i;
			}
			while (csv.ReadNextRecord()) {
				CrimeEntry crime = new CrimeEntry ();
				
				crime.shift = csv [myObjectMap ["SHIFT"]];
				crime.offense = csv [myObjectMap ["OFFENSE"]];
				crime.method = csv [myObjectMap ["METHOD"]];
				crime.ward = csv [myObjectMap ["WARD"]];
				crime.district = csv [myObjectMap ["DISTRICT"]];
				crime.reportDate = csv [myObjectMap ["REPORTDATETIME"]];
				crimeList.Add (crime);
			}
		}
		return crimeList;
	}

	void renderCrimesTotal(List<CrimeEntry> crimes){
		int ward1Count = 0, ward2Count = 0, ward3Count = 0, 
		ward4Count = 0, ward5Count = 0, ward6Count = 0, 
		ward7Count = 0, ward8Count = 0;
		int totalCount = 0;
		
		foreach (CrimeEntry crime in crimes) {
			switch (crime.ward) {
			case "1":
				ward1Count++;
				break;
			case "2":
				ward2Count++;
				break;
			case "3":
				ward3Count++;
				break;
			case "4":
				ward4Count++;
				break;
			case "5":
				ward5Count++;
				break;
			case "6":
				ward6Count++;
				break;
			case "7":
				ward7Count++;
				break;
			case "8":
				ward8Count++;
				break;
			default:
				break;
			}
			totalCount++;
		}
		
		Hashtable w1Scale = new Hashtable ();
		w1Scale.Add ("y", .5-(1-(double)ward1Count / (double)totalCount));
		w1Scale.Add ("speed", 3.0);
		iTween.MoveTo (GameObject.Find ("Ward1"), w1Scale);
		
		Hashtable w2Scale = new Hashtable ();
		w2Scale.Add ("y", .5-(1-(double)ward2Count / (double)totalCount));
		w2Scale.Add ("speed", 3.0);
		iTween.MoveTo (GameObject.Find ("Ward2"), w2Scale);
		
		Hashtable w3Scale = new Hashtable ();
		w3Scale.Add ("y", .5-(1-(double)ward3Count / (double)totalCount));
		w3Scale.Add ("speed", 3.0);
		iTween.MoveTo (GameObject.Find ("Ward3"), w3Scale);
		
		Hashtable w4Scale = new Hashtable ();
		w4Scale.Add ("y", .5-(1-(double)ward4Count / (double)totalCount));
		w4Scale.Add ("speed", 3.0);
		iTween.MoveTo (GameObject.Find ("Ward4"), w4Scale);
		
		Hashtable w5Scale = new Hashtable ();
		w5Scale.Add ("y", .5-(1-(double)ward5Count / (double)totalCount));
		w5Scale.Add ("speed", 3.0);
		iTween.MoveTo (GameObject.Find ("Ward5"), w5Scale);
		
		Hashtable w6Scale = new Hashtable ();
		w6Scale.Add ("y", .5-(1-(double)ward6Count / (double)totalCount));
		w6Scale.Add ("speed", 3.0);
		iTween.MoveTo (GameObject.Find ("Ward6"), w6Scale);
		
		Hashtable w7Scale = new Hashtable ();
		w7Scale.Add ("y", .5-(1-(double)ward7Count / (double)totalCount));
		w7Scale.Add ("speed", 3.0);
		iTween.MoveTo (GameObject.Find ("Ward7"), w7Scale);
		
		Hashtable w8Scale = new Hashtable ();
		w8Scale.Add ("y", .5-(1-(double)ward8Count / (double)totalCount));
		w8Scale.Add ("speed", 3.0);
		iTween.MoveTo (GameObject.Find ("Ward8"), w8Scale);
	}
}