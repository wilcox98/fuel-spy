export const FuelDropdown = ({ fuelType, setFuelType }) => {
  const fuelTypes = ["Super", "Diesel", "Kerosene"];

  return (
    <select
      className="form-select"
      value={fuelType}
      onChange={(e) => setFuelType(e.target.value)}
    >
      {fuelTypes.map((fuel, index) => (
        <option value={fuel} key={index}>
          {fuel}
        </option>
      ))}
    </select>
  );
};
