import React, { useState, useEffect } from 'react';
import './App.css';

function App() {
  const [activeTab, setActiveTab] = useState('invited');
  const [invitedLeads, setInvitedLeads] = useState([]);
  const [acceptedLeads, setAcceptedLeads] = useState([]);
  const [loading, setLoading] = useState(false);

  const API_BASE = 'https://localhost:7013/api/Leads'; // Ajuste a porta se necessário

  // Buscar leads convidados
  const fetchInvitedLeads = async () => {
    setLoading(true);
    try {
      const response = await fetch(`${API_BASE}/invited`);
      const data = await response.json();
      setInvitedLeads(data);
    } catch (error) {
      console.error('Erro ao buscar leads convidados:', error);
    }
    setLoading(false);
  };

  // Buscar leads aceitos
  const fetchAcceptedLeads = async () => {
    setLoading(true);
    try {
      const response = await fetch(`${API_BASE}/accepted`);
      const data = await response.json();
      setAcceptedLeads(data);
    } catch (error) {
      console.error('Erro ao buscar leads aceitos:', error);
    }
    setLoading(false);
  };

  // Aceitar lead
  const acceptLead = async (id) => {
    try {
      await fetch(`${API_BASE}/${id}/accept`, { method: 'POST' });
      // Atualizar as listas
      fetchInvitedLeads();
      fetchAcceptedLeads();
    } catch (error) {
      console.error('Erro ao aceitar lead:', error);
    }
  };

  // Recusar lead
  const declineLead = async (id) => {
    try {
      await fetch(`${API_BASE}/${id}/decline`, { method: 'POST' });
      // Atualizar a lista
      fetchInvitedLeads();
    } catch (error) {
      console.error('Erro ao recusar lead:', error);
    }
  };

  // Carregar dados ao iniciar
  useEffect(() => {
    fetchInvitedLeads();
    fetchAcceptedLeads();
  }, []);

  // Componente do card de lead
  const LeadCard = ({ lead, showActions = false }) => (
    <div className="lead-card">
      <h3>{lead.contactFirstName || lead.contactFullName}</h3>
      
      <div className="lead-info">
        <p><strong>ID:</strong> {lead.id}</p>
        <p><strong>Data:</strong> {new Date(lead.dateCreated).toLocaleDateString()}</p>
        <p><strong>Suburb:</strong> {lead.suburb}</p>
        <p><strong>Categoria:</strong> {lead.category}</p>
        <p><strong>Price:</strong> ${lead.price.toLocaleString()}</p>
        <p><strong>Status:</strong> {lead.status}</p>
      </div>

      {lead.contactPhone && <p><strong>Telefone:</strong> {lead.contactPhone}</p>}
      {lead.contactEmail && <p><strong>Email:</strong> {lead.contactEmail}</p>}
      
      <p><strong>Descrição:</strong> {lead.description}</p>

      {showActions && (
        <div className="lead-actions">
          <button 
            className="btn btn-accept" 
            onClick={() => acceptLead(lead.id)}
          >
            Accept
          </button>
          <button 
            className="btn btn-decline" 
            onClick={() => declineLead(lead.id)}
          >
            Decline
          </button>
        </div>
      )}
    </div>
  );

  return (
    <div className="App">
      <header className="App-header">
        <h1>MRV Leads Management</h1>
        
        <div className="tabs">
          <button 
            className={activeTab === 'invited' ? 'tab active' : 'tab'}
            onClick={() => setActiveTab('invited')}
          >
            Invited
          </button>
          <button 
            className={activeTab === 'accepted' ? 'tab active' : 'tab'}
            onClick={() => setActiveTab('accepted')}
          >
            Accepted
          </button>
        </div>

        <div className="tab-content">
          {loading && <p>Carregando...</p>}
          
          {activeTab === 'invited' ? (
            <div>
              <h2>Invited Leads</h2>
              <div className="leads-container">
                {invitedLeads.length === 0 && !loading && <p>Nenhum lead encontrado.</p>}
                {invitedLeads.map(lead => (
                  <LeadCard key={lead.id} lead={lead} showActions={true} />
                ))}
              </div>
            </div>
          ) : (
            <div>
              <h2>Accepted Leads</h2>
              <div className="leads-container">
                {acceptedLeads.length === 0 && !loading && <p>Nenhum lead aceito ainda.</p>}
                {acceptedLeads.map(lead => (
                  <LeadCard key={lead.id} lead={lead} showActions={false} />
                ))}
              </div>
            </div>
          )}
        </div>
      </header>
    </div>
  );
}

export default App;