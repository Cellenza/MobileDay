using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Coffee.Services
{
	public class Parameters
	{
		public List<string> dataset { get; set; }
		public string timezone { get; set; }
		public int rows { get; set; }
		public string format { get; set; }
		public List<string> facet { get; set; }
	}

	public class Fields
	{
		public int prix_comptoir { get; set; }
		public int arrondissement { get; set; }
		public string adresse { get; set; }
		public string prix_salle { get; set; }
		public string nom_du_cafe { get; set; }
		public string prix_terasse { get; set; }
		public string date { get; set; }
		public List<double> geo_latitude { get; set; }
	}

	public class Geometry
	{
		public string type { get; set; }
		public List<double> coordinates { get; set; }
	}

	public class Record
	{
		public string datasetid { get; set; }
		public string recordid { get; set; }
		public Fields fields { get; set; }
		public Geometry geometry { get; set; }
		public string record_timestamp { get; set; }
	}

	public class Facet
	{
		public string name { get; set; }
		public string path { get; set; }
		public int count { get; set; }
		public string state { get; set; }
	}

	public class FacetGroup
	{
		public string name { get; set; }
		public List<Facet> facets { get; set; }
	}

	public class RootObject
	{
		public int nhits { get; set; }
		public Parameters parameters { get; set; }
		public List<Record> records { get; set; }
		public List<FacetGroup> facet_groups { get; set; }
	}
}

