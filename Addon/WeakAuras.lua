-- --------------------------------
-- ADDON MOSAIC v1.4s alpha -------------------------
-- Quadrados de HP, Mana, X, Y, Facing (dinâmico com velocidade)
-- Atualização automática a cada 0,5 segundos
-- Agora com precisão aumentada (2 casas decimais) e fator de codificação 2.8
-- --------------------------------

local largura = GetScreenWidth()
local altura = GetScreenHeight()

local margem_esquerda = largura * 0.02
local topo = altura * 0.15

-- --------------------------------
-- MOD 1 -------------------------
-- CRIA QUADRADO DE HP
-- --------------------------------
local hp_quad = CreateFrame("Frame", nil, UIParent)
hp_quad:SetPoint("TOPLEFT", UIParent, "TOPLEFT", margem_esquerda, -topo)
hp_quad:SetSize(16, 16)

local tex_hp = hp_quad:CreateTexture(nil, "BACKGROUND")
tex_hp:SetAllPoints()
hp_quad.texture = tex_hp

-- --------------------------------
-- MOD 2 -------------------------
-- CRIA QUADRADO DE MANA
-- --------------------------------
local mana_quad = CreateFrame("Frame", nil, UIParent)
mana_quad:SetPoint("LEFT", hp_quad, "RIGHT", 2, 0)
mana_quad:SetSize(16, 16)

local tex_mana = mana_quad:CreateTexture(nil, "BACKGROUND")
tex_mana:SetAllPoints()
tex_mana:SetColorTexture(0, 0, 1)
mana_quad.texture = tex_mana

-- --------------------------------
-- MOD 3 -------------------------
-- CRIA QUADRADO DE X
-- --------------------------------
local x_quad = CreateFrame("Frame", nil, UIParent)
x_quad:SetPoint("TOPLEFT", hp_quad, "BOTTOMLEFT", 0, -10)
x_quad:SetSize(16, 16)

local tex_x = x_quad:CreateTexture(nil, "BACKGROUND")
tex_x:SetAllPoints()
x_quad.texture = tex_x

-- --------------------------------
-- MOD 4 -------------------------
-- CRIA QUADRADO DE Y
-- --------------------------------
local y_quad = CreateFrame("Frame", nil, UIParent)
y_quad:SetPoint("LEFT", x_quad, "RIGHT", 2, 0)
y_quad:SetSize(16, 16)

local tex_y = y_quad:CreateTexture(nil, "BACKGROUND")
tex_y:SetAllPoints()
y_quad.texture = tex_y

-- --------------------------------
-- MOD 5 -------------------------
-- CRIA QUADRADO DE FACING
-- --------------------------------
local facing_quad = CreateFrame("Frame", nil, UIParent)
facing_quad:SetPoint("LEFT", y_quad, "RIGHT", 2, 0)
facing_quad:SetSize(16, 16)

local tex_facing = facing_quad:CreateTexture(nil, "BACKGROUND")
tex_facing:SetAllPoints()
facing_quad.texture = tex_facing

-- --------------------------------
-- MOD 6 -------------------------
-- CRIA TEXTOS DE X E Y
-- --------------------------------
local x_text = UIParent:CreateFontString(nil, "OVERLAY", "GameFontNormal")
x_text:SetPoint("TOPLEFT", x_quad, "BOTTOMLEFT", 0, -5)
x_text:SetText("X = 0.0")

local y_text = UIParent:CreateFontString(nil, "OVERLAY", "GameFontNormal")
y_text:SetPoint("TOPLEFT", x_text, "BOTTOMLEFT", 0, -2)
y_text:SetText("Y = 0.0")

-- --------------------------------
-- MOD 7 -------------------------
-- ROTINA DE ATUALIZAÇÃO (HP, Mana, X, Y, Facing + Velocidade)
-- Agora com precisão de 2 casas decimais e fator 2.8
-- --------------------------------
C_Timer.NewTicker(0.3, function()
    -- Atualiza HP
    local vida_atual = UnitHealth("player")
    local vida_max = UnitHealthMax("player")
    if vida_max ~= 0 then
        local vida_percent = vida_atual / vida_max
        hp_quad.texture:SetColorTexture(0, vida_percent, 0)
    end

    -- Atualiza Mana
    local mana_atual = UnitPower("player", 0)
    local mana_max = UnitPowerMax("player", 0)
    if mana_max ~= 0 then
        local mana_percent = mana_atual / mana_max
        mana_quad.texture:SetColorTexture(0, 0, mana_percent)
    end

    -- Atualiza X e Y usando C_Map
    local mapID = C_Map.GetBestMapForUnit("player")
    if mapID then
        local pos = C_Map.GetPlayerMapPosition(mapID, "player")
        if pos then
            local posX = pos.x * 100
            local posY = pos.y * 100

            posX = math.floor(posX * 100 + 0.5) / 100
            posY = math.floor(posY * 100 + 0.5) / 100

            x_text:SetText("X = " .. posX)
            y_text:SetText("Y = " .. posY)

            local inteiroX = math.floor(posX)
            local decimalX = math.floor((posX - inteiroX) * 100)

            local inteiroY = math.floor(posY)
            local decimalY = math.floor((posY - inteiroY) * 100)

            tex_x:SetColorTexture((inteiroX * 2.8) / 255, (decimalX * 2.8) / 255, 0)
            tex_y:SetColorTexture((inteiroY * 2.8) / 255, (decimalY * 2.8) / 255, 0)
        end
    end

    -- Atualiza Facing + Velocidade
    local facing = GetPlayerFacing()
    local speed = GetUnitSpeed("player")
    if facing and speed then
        local red = math.min((facing / (2 * math.pi)) * 255, 255) / 255
        local green = math.min(speed * 15, 255) / 255
        tex_facing:SetColorTexture(red, green, 0)
    end
end)
