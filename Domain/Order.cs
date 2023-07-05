using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public record Order(int Id, IEnumerable<Product> products, DateTime created);
