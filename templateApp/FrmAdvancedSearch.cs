using Dma.DatasourceLoader;
using Dma.DatasourceLoader.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using templateApp.Shared;
using templateApp.ViewModels;

namespace templateApp
{
    public partial class FrmAdvancedSearch : Form
    {
        private List<FilterCriteriaControl> filterCriteriaList = new List<FilterCriteriaControl>();
        private List<FilterCriteria> initialCriterias;
        public event EventHandler OnSearch;
        public event EventHandler OnSearchAndSave;
        public List<FilterCriteria> FilterCriterias => filterCriteriaList
            .Select(f => f.Criteria)
            .ToList();
        public FrmAdvancedSearch(List<FilterCriteria> initialCriterias)
        {
            InitializeComponent();
            this.initialCriterias = initialCriterias;
        }

        private void InitializeState(List<FilterCriteria> initialCriterias)
        {
            var i = 0;
            foreach (var c in initialCriterias)
            {
                var control = new FilterCriteriaControl(isFirst: i == 0, criteria: c);
                control.Dock = DockStyle.Bottom;
                addFilterCriteria(control);
                i++;
            }
        }

        private void FrmAdvancedSearch_Load(object sender, EventArgs e)
        {
            if (initialCriterias != null)
            {
                InitializeState(initialCriterias);
            }
            if (filterCriteriaList.Count > 0) return;
            FilterCriteriaControl filterCriteria = new FilterCriteriaControl(isFirst: true);
            filterCriteria.Dock = DockStyle.Top;
            addFilterCriteria(filterCriteria);

        }

        private void addFilterCriteria(FilterCriteriaControl filterCriteria)
        {
            filterCriteria.RemoveButtonClick += (s, args) =>
            {
                if (filterCriteriaList.Count == 1)
                {
                    return;
                }
                removeFilterCriteria(filterCriteria);
            };
            filterCriteriaList.Add(filterCriteria);
            filterPanel.Controls.Add(filterCriteria);
        }

        private void removeFilterCriteria(FilterCriteriaControl filterCriteria)
        {
            filterCriteriaList.Remove(filterCriteria);
            filterPanel.Controls.Remove(filterCriteria);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Create a new FilterCriteria control
            FilterCriteriaControl filterCriteria = new FilterCriteriaControl();
            

            // Add the new filter criteria to the list and the panel
            filterCriteria.Dock = DockStyle.Bottom;
            addFilterCriteria(filterCriteria);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnSearchAndSave?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnSearch?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
