import { useState } from "react";
import { driveService } from "../../services/api";

function DriveForm({ onDriveCreated, editData }) {
    const [form, setForm] = useState({
        name: editData?.name || "",
        date: editData?.date ? editData.date.split("T")[0] : "",
        location: editData?.location || ""
    });

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        if (editData) {
            driveService.update(editData.id, {
                ...form,
                isActive: editData.isActive
            }).then(() => onDriveCreated());
        } else {
            driveService.create(form).then(() => onDriveCreated());
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h3>{editData ? "Edit Drive" : "Add Drive"}</h3>
            <input name="name" placeholder="Name" value={form.name} onChange={handleChange} required />
            <input name="date" type="date" value={form.date} onChange={handleChange} required />
            <input name="location" placeholder="Location" value={form.location} onChange={handleChange} required />
            <button type="submit">{editData ? "Update" : "Save"}</button>
        </form>
    );
}

export default DriveForm;