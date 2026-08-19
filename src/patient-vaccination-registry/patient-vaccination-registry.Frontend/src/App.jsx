import { useState, useEffect } from "react";
import PersonList from "./components/persons/PersonList";
import PersonForm from "./components/persons/PersonForm";
import VaccineList from "./components/vaccines/VaccineList";
import VaccineForm from "./components/vaccines/VaccineForm";
import DriveList from "./components/drives/DriveList";
import DriveForm from "./components/drives/DriveForm";
import ApplicationList from "./components/applications/ApplicationList";
import ApplicationForm from "./components/applications/ApplicationForm";
import { personService, vaccineService, driveService, applicationService } from "./services/api";
import "./App.css";

function App() {
    const [section, setSection] = useState("dashboard");
    const [refresh, setRefresh] = useState(false);
    const [showForm, setShowForm] = useState(false);
    const [editingData, setEditingData] = useState(null);
    const [stats, setStats] = useState({ persons: 0, vaccines: 0, drives: 0, applications: 0 });

    useEffect(() => {
        personService.getAll().then(data => setStats(s => ({ ...s, persons: data.length })));
        vaccineService.getAll().then(data => setStats(s => ({ ...s, vaccines: data.length })));
        driveService.getAll().then(data => setStats(s => ({ ...s, drives: data.length })));
        applicationService.getAll().then(data => setStats(s => ({ ...s, applications: data.length })));
    }, [refresh]);

    const handleDone = () => {
        setRefresh(r => !r);
        setShowForm(false);
        setEditingData(null);
    };

    const handleEdit = (data) => {
        setEditingData(data);
        setShowForm(true);
    };

    const handleSection = (s) => {
        setSection(s);
        setShowForm(false);
        setEditingData(null);
    };

    return (
        <div className="app">
            <nav className="navbar">
                <div className="brand">💉 VaxRegistry</div>
                <div className="nav-links">
                    {["dashboard", "persons", "vaccines", "drives", "applications"].map(s => (
                        <button key={s} className={`nav-btn ${section === s ? "active" : ""}`} onClick={() => handleSection(s)}>
                            {s.charAt(0).toUpperCase() + s.slice(1)}
                        </button>
                    ))}
                </div>
            </nav>

            <div className="content">
                {section === "dashboard" && (
                    <div className="dashboard">
                        <h1 className="welcome-title">Welcome to VaxRegistry 💉</h1>
                        <p className="welcome-desc">Your complete vaccination campaign management system. Register persons, vaccines, drives and track every dose administered.</p>
                        <div className="stats-grid">
                            <div className="stat-card" onClick={() => handleSection("persons")}>
                                <span className="stat-label">Persons</span>
                                <span className="stat-number">{stats.persons}</span>
                            </div>
                            <div className="stat-card" onClick={() => handleSection("vaccines")}>
                                <span className="stat-label">Vaccines</span>
                                <span className="stat-number">{stats.vaccines}</span>
                            </div>
                            <div className="stat-card" onClick={() => handleSection("drives")}>
                                <span className="stat-label">Drives</span>
                                <span className="stat-number">{stats.drives}</span>
                            </div>
                            <div className="stat-card" onClick={() => handleSection("applications")}>
                                <span className="stat-label">Applications</span>
                                <span className="stat-number">{stats.applications}</span>
                            </div>
                        </div>
                    </div>
                )}

                {section !== "dashboard" && (
                    <div>
                        <div className="section-header">
                            <div>
                                <h1>{section.charAt(0).toUpperCase() + section.slice(1)}</h1>
                                {section === "persons" && <p className="section-desc">Register the citizens who will participate in vaccination campaigns.</p>}
                                {section === "vaccines" && <p className="section-desc">Register the vaccines available for vaccination drives.</p>}
                                {section === "drives" && <p className="section-desc">Register and manage scheduled vaccination drives.</p>}
                                {section === "applications" && <p className="section-desc">Register the doses administered to each person during vaccination drives.</p>}
                            </div>
                            <button className="add-btn" onClick={() => { setShowForm(!showForm); setEditingData(null); }}>
                                {showForm && !editingData ? "✕ Cancel" : "+ Add"}
                            </button>
                        </div>

                        {showForm && (
                            <div className="form-container">
                                {section === "persons" && <PersonForm key={editingData?.id || "new"} onPersonCreated={handleDone} editData={editingData} />}
                                {section === "vaccines" && <VaccineForm key={editingData?.id || "new"} onVaccineCreated={handleDone} editData={editingData} />}
                                {section === "drives" && <DriveForm key={editingData?.id || "new"} onDriveCreated={handleDone} editData={editingData} />}
                                {section === "applications" && <ApplicationForm key={editingData?.id || "new"} onApplicationCreated={handleDone} editData={editingData} />}
                            </div>
                        )}

                        <div className="list-container">
                            {section === "persons" && <PersonList refresh={refresh} onEdit={handleEdit} />}
                            {section === "vaccines" && <VaccineList refresh={refresh} onEdit={handleEdit} />}
                            {section === "drives" && <DriveList refresh={refresh} onEdit={handleEdit} />}
                            {section === "applications" && <ApplicationList refresh={refresh} onEdit={handleEdit} />}
                        </div>
                    </div>
                )}
            </div>
        </div>
    );
}

export default App;