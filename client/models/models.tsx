export interface Station {
  lat: number;
  lon: number;
  stationId: number;
  tags: Tags;
  fuelPrice: FuelPrice;
}

export interface Tags {
  stationId: number;
  id: number;
  city: string;
  street: any;
  amenity: string;
  brand: string;
  name: string;
  operator: any;
}
export interface FuelPrice {
  createdAt: any;
  petrol: number;
  kerosene: number;
  diesel: number;
}
