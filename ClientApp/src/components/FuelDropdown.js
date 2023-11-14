import { useState } from "react";
import Dropdown from "react-dropdown";

function FuelDropdown() {
  const [fuel, setFuel] = useState();
  const fuelTypes = ["Super", "Diesel", "Kerosene"];
  const handleSelectFuel = (option) => {
    console.log(option);
    setFuel(option.value);
  };
  return (
    // <Dropdown
    //   className="form-select"
    //   options={fuelTypes}
    //   onChange={handleSelectFuel}
    //   value={fuel}
    //   placeholder="Select an option"
    // />
    <select className="form-select">
      {fuelTypes.map((fuel, index) => (
        <option onSelect={handleSelectFuel} key={index} value={fuel}>
          {fuel}
        </option>
      ))}
    </select>
  );
}

export default FuelDropdown;
