document.addEventListener('DOMContentLoaded', function () {
    const lang = {
        "Select a definition": "Selecione uma definição",
        "- Website": "- Github",
        "Send email to%": "Enviar email para",
        "No parameters": "Sem parâmetros",
        "Parameters": "Parâmetros",
        "Try it out": "Testar",
        "Responses": "Respostas",
        "Code": "Código",
        "Description": "Descrição",
        "No links": "Sem links",
        "Media type": "Tipo de retorno",
        "Controls Accept header.": "Controla o cabeçalho Accept.",
        "Example value": "Valor de exemplo",
        "Request body": "Corpo da requisição",
        "Created": "Criado",
        "Bad Request": "Requisição inválida",
        "Not Found": "Não encontrado",
        "No Content": "Sem conteúdo",
    };

    const langKeyWithPercent = Array.from(Object.keys(lang)).filter(key => key.includes('%')).map(key => {
        return {
            key: key.replace('%', ''),
            value: lang[key]
        };
    });

    function translateTextNode(node) {
        const key = node.innerText.trim();
        if (key === undefined || key === '') {
            return;
        }

        const translated = getLang(key);

        if (translated) {
            node.innerText = translated;
        }
    }

    function getLang(key) {
        const langKey = lang[key];
        if (langKey) {
            return langKey;
        }

        const langKeyLike = langKeyWithPercent.find(item => key.includes(item.key));
        if (langKeyLike) {
            const langLikeTranslated = langKeyLike.value + key.replace(langKeyLike.key, '');
            if (langLikeTranslated) {
                return langLikeTranslated;
            }
        }

        return null;
    }

    function walkDOM(node) {
        if (!node.childElementCount && ['SMALL', 'SPAN', 'BUTTON', 'H4', 'TD', 'P', 'I', 'A'].includes(node.nodeName)) {
            translateTextNode(node);
        } else {
            for (let child = node.firstChild; child; child = child.nextSibling) {
                walkDOM(child);
            }
        }
    }

    const walkDomInterval = setInterval(() => {
        const root = document.getElementById('swagger-ui');
        if (root) {
            clearInterval(walkDomInterval);
            walkDOM(root);
        }
    }, 200);

    const opblockInterval = setInterval(() => {
        const opblockSummaries = document.querySelectorAll('.opblock-summary');
        if (opblockSummaries.length > 0) {
            clearInterval(opblockInterval);
            opblockSummaries.forEach(opblockSummary => opblockSummary.addEventListener('click', () => {
                let state = opblockSummary.dataset.state;
                state = state ? (state == 'open' ? 'close' : 'open') : 'open';
                opblockSummary.dataset.state = state;

                const opblock = opblockSummary.parentElement;
                const opblockDetailsInterval = setInterval(() => {
                    if (state == 'close') {
                        clearInterval(opblockDetailsInterval);
                        return;
                    }

                    const opblockDetails = opblock.querySelector('.no-margin');
                    if (opblockDetails) {
                        clearInterval(opblockDetailsInterval);
                        walkDOM(opblockDetails);
                    }
                }, 50);
            }));
        }
    }, 50);

    const style = document.createElement('style');
    style.innerHTML = `
        .swagger-ui .parameter__name.required:after {
            content: "obrigatório";
        }
    `;
    document.head.appendChild(style);
});
