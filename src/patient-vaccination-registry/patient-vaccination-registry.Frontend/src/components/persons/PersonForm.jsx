import { useState } from "react";
import { personService } from "../../services/api";

function PersonForm({ onPersonCreated, editData }) {
    const [form, setForm] = useState({
        name: editData?.name || "",
        idNumber: editData?.idNumber || "",
        birthDate: editData?.birthDate ? editData.birthDate.split("T")[0] : ""
    });

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        if (editData) {
            personService.update(editData.id, {
                ...form,
                isActive: editData.isActive
            }).then(() => onPersonCreated());
        } else {
            personService.create(form).then(() => onPersonCreated());
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h3>{editData ? "Edit Person" : "Add Person"}</h3>
            <input name="name" placeholder="Name" value={form.name} onChange={handleChange} required />
            <input name="idNumber" placeholder="ID Number" value={form.idNumber} onChange={handleChange} required />
            <input name="birthDate" type="date" value={form.birthDate} onChange={handleChange} required />
            <button type="submit">{editData ? "Update" : "Save"}</button>
        </form>
    );
}

export default PersonForm;