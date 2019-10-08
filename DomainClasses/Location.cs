using System.Collections.Generic;

public class Location{

  public int LocationId { get; set; }
  public string StreetAddress {get;set;}
  public string OpenTime{get;set;}
  public string CloseTime{get;set;}
  public List<Unit> BrewingUnits{get;set;}
}