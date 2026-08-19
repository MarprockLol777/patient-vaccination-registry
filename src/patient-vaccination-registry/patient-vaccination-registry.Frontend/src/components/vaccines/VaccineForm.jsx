import { useState } from "react";
import { vaccineService } from "../../services/api";

function VaccineForm({ onVaccineCreated, editData }) {
    const [form, setForm] = useState({
        name: editData?.name || "",
        manufacturer: editData?.manufacturer || "",
        batch: editData?.batch || "",
        requiredDoses: editData?.requiredDoses || ""
    });

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        if (editData) {
            vaccineService.update(editData.id, {
                ...form,
                isActive: editData.isActive
            }).then(() => onVaccineCreated());
        } else {
            vaccineService.create(form).then(() => onVaccineCreated());
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h3>{editData ? "Edit Vaccine" : "Add Vaccine"}</h3>
            <input name="name" placeholder="Name" value={form.name} onChange={handleChange} required />
            <input name="manufacturer" placeholder="Manufacturer" value={form.manufacturer} onChange={handleChange} required />
            <input name="batch" placeholder="Batch" value={form.batch} onChange={handleChange} required />
            <input name="requiredDoses" type="number" min="1" placeholder="Required Doses" value={form.requiredDoses} onChange={handleChange} required />
            <button type="submit">{editData ? "Update" : "Save"}</button>
        </form>
    );
}

export default VaccineForm;