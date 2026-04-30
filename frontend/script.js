const API_URL = "https://localhost:7133/api/transactions"; // ajustar a porta

const formatar = (valor) => // formatar moeda
  valor.toLocaleString("pt-BR", { style: "currency", currency: "BRL" });

const form = document.getElementById("form");
const lista = document.getElementById("lista");
const saldo = document.getElementById("saldo");

// carregar ao abrir
window.onload = () => {
  carregarTransacoes();
  carregarSaldo();
};

// adicionar transação
form.addEventListener("submit", async (e) => {
  e.preventDefault();

  const tipo = document.getElementById("tipo").value;
  const categoria = document.getElementById("categoria").value;
  const quantidade = parseFloat(document.getElementById("quantidade").value);
  if (!tipo || !categoria || !quantidade){
    alert("Preencha todos os campos!");
    return;
}

  await fetch(API_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({ tipo, categoria, quantidade })
  });

  form.reset();
  carregarTransacoes();
  carregarSaldo();
});

// listar
async function carregarTransacoes() {
  const res = await fetch(API_URL);
  const data = await res.json();

  lista.innerHTML = "";

  data.forEach(t => {
  const li = document.createElement("li");
  li.classList.add("list-group-item", "d-flex", "justify-content-between", "align-items-center");

  li.innerHTML = `
    <div>
      <strong>${t.categoria}</strong>
      <span class="${t.tipo === 'ganho' ? 'text-success' : 'text-danger'}">
        ${t.tipo === 'ganho' ? '+' : '-'} ${formatar(t.quantidade)}
      </span>
    </div>

    <button class="btn btn-sm btn-outline-danger" onclick="deletarTransacao(${t.id})">
      Excluir
    </button>
  `;

  lista.appendChild(li);
});
}

// saldo
async function carregarSaldo() {
  const res = await fetch(`${API_URL}/balance`);
  const data = await res.json();

    document.getElementById("ganhos").textContent = formatar(data.ganhoTotal);
    document.getElementById("despesas").textContent = formatar(data.despesaTotal);
    document.getElementById("saldo").textContent = formatar(data.balance);
}
async function deletarTransacao(id) {
  await fetch(`${API_URL}/${id}`, {
    method: "DELETE"
  });

  carregarTransacoes();
  carregarSaldo();
}
async function limparTudo() {

  const confirmar = confirm("Tem certeza que deseja apagar todas as transações?");

  if (!confirmar) return;

  await fetch(API_URL, {
    method: "DELETE"
  });

  carregarTransacoes();
  carregarSaldo();
}